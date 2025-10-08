using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using PhanMemBanVe.Models;
using System.Drawing;
using PhanMemBanVe.Data; // added

namespace PhanMemBanVe
{
    public partial class FormCustomers : Form
    {
        public bool SelectionMode { get; set; }
        public Customer SelectedCustomer { get; private set; }

        private TicketManagementContext _context;
        private BindingSource _bs;
        private BindingSource _bsSales;
        private DataGridView dgvTicketSales;
        private Label lblTicketSummary;

        private enum EditMode { None, Add, Edit }
        private EditMode _mode = EditMode.None;
        private Customer _editingEntity;

        private Dictionary<int, TicketStat> _ticketStat = new Dictionary<int, TicketStat>();
        private class TicketStat
        {
            public int Count;
            public decimal Total;
        }

        public FormCustomers()
        {
            InitializeComponent();
            _context = new TicketManagementContext();
            _bs = new BindingSource();
            _bsSales = new BindingSource();

            dgvCustomers.AutoGenerateColumns = false;
            SetupGridColumns();
            dgvCustomers.CellFormatting += dgvCustomers_CellFormatting;

            SetupTicketSalesGrid();
            ToggleEdit(false);
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SetupGridColumns()
        {
            dgvCustomers.Columns.Clear();

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerCode",
                HeaderText = "Mã KH",
                Width = 80
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FullName",
                HeaderText = "Họ tên",
                Width = 160
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Điện thoại",
                Width = 100
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TicketCount",
                HeaderText = "Số vé",
                Width = 60
            });

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalSpent",
                HeaderText = "Tổng (VNĐ)",
                Width = 100,
                DefaultCellStyle = { Format = "N0" }
            });

            dgvCustomers.DataSource = _bs;
        }

        private void SetupTicketSalesGrid()
        {
            dgvTicketSales = new DataGridView
            {
                Name = "dgvTicketSales",
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = false,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Height = 160
            };

            dgvTicketSales.Left = dgvCustomers.Left;
            dgvTicketSales.Width = dgvCustomers.Width;
            dgvTicketSales.Top = this.ClientSize.Height - dgvTicketSales.Height - 10;

            this.Resize += (s, e) =>
            {
                dgvTicketSales.Width = dgvCustomers.Width;
                dgvTicketSales.Top = this.ClientSize.Height - dgvTicketSales.Height - 10;
                if (lblTicketSummary != null)
                {
                    lblTicketSummary.Top = dgvTicketSales.Top - lblTicketSummary.Height - 4;
                    lblTicketSummary.Left = dgvTicketSales.Left;
                }
            };

            dgvTicketSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TicketCode",
                HeaderText = "Mã Vé",
                Width = 120
            });
            dgvTicketSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SeatNumber",
                HeaderText = "Ghế",
                Width = 50
            });
            dgvTicketSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AreaName",
                HeaderText = "Khu vực",
                Width = 90
            });
            dgvTicketSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Giá",
                Width = 80,
                DefaultCellStyle = { Format = "N0" }
            });
            dgvTicketSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SaleDate",
                HeaderText = "Ngày bán",
                Width = 130,
                DefaultCellStyle = { Format = "yyyy-MM-dd HH:mm" }
            });
            dgvTicketSales.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsRefunded",
                HeaderText = "Hoàn?",
                Width = 55
            });

            dgvTicketSales.DataSource = _bsSales;

            lblTicketSummary = new Label
            {
                AutoSize = true,
                Text = "Vé: 0 | Tổng tiền: 0",
                Font = new Font(Font, FontStyle.Bold)
            };

            this.Controls.Add(lblTicketSummary);
            this.Controls.Add(dgvTicketSales);
            lblTicketSummary.Left = dgvTicketSales.Left;
            lblTicketSummary.Top = dgvTicketSales.Top - lblTicketSummary.Height - 4;
        }

        private void LoadData(string keyword = null)
        {
            var query = _context.Customers.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(c =>
                    c.CustomerCode.Contains(keyword) ||
                    c.FullName.Contains(keyword) ||
                    (c.Phone != null && c.Phone.Contains(keyword))
                );
            }

            var list = query.OrderBy(c => c.CustomerCode).ToList();
            _bs.DataSource = list;

            _ticketStat = _context.TicketSales
                .GroupBy(ts => ts.CustomerId)
                .Select(g => new
                {
                    CustomerId = g.Key,
                    Count = g.Count(),
                    Total = g.Where(x => !x.IsRefunded && x.Price.HasValue)
                             .Select(x => x.Price.Value)
                             .DefaultIfEmpty(0m)
                             .Sum()
                })
                .ToDictionary(x => x.CustomerId, x => new TicketStat { Count = x.Count, Total = x.Total });

            dgvCustomers.ClearSelection();
            ClearDetails();
            ClearTicketSales();
        }

        private void ClearTicketSales()
        {
            _bsSales.DataSource = null;
            if (lblTicketSummary != null)
                lblTicketSummary.Text = "Vé: 0 | Tổng tiền: 0";
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode != EditMode.None) return;
            if (dgvCustomers.CurrentRow == null)
            {
                ClearDetails();
                ClearTicketSales();
                return;
            }
            var entity = dgvCustomers.CurrentRow.DataBoundItem as Customer;
            ShowDetails(entity);
            if (entity != null) LoadTicketSalesForCustomer(entity.CustomerId);
        }

        private void LoadTicketSalesForCustomer(int customerId)
        {
            var sales = _context.TicketSales
                .Where(ts => ts.CustomerId == customerId)
                .OrderByDescending(ts => ts.SaleDate)
                .AsNoTracking()
                .ToList();

            _bsSales.DataSource = sales;

            decimal total = sales
                .Where(s => !s.IsRefunded && s.Price.HasValue)
                .Sum(s => s.Price.Value);

            int count = sales.Count;
            int refunded = sales.Count(s => s.IsRefunded);

            if (lblTicketSummary != null)
            {
                lblTicketSummary.Text =
                    $"Vé: {count} (Hoàn: {refunded}) | Tổng tiền (chưa hoàn): {total:N0}";
            }
        }

        private void ShowDetails(Customer c)
        {
            if (c == null)
            {
                ClearDetails();
                return;
            }
            txtCustomerCode.Text = c.CustomerCode;
            txtFullName.Text = c.FullName;
            txtPhone.Text = c.Phone;
        }

        private void ClearDetails()
        {
            txtCustomerCode.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _mode = EditMode.Add;
            _editingEntity = new Customer();
            ClearDetails();
            ClearTicketSales();
            ToggleEdit(true);
            txtCustomerCode.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            var selected = dgvCustomers.CurrentRow.DataBoundItem as Customer;
            if (selected == null) return;
            _editingEntity = _context.Customers.FirstOrDefault(x => x.CustomerId == selected.CustomerId);
            if (_editingEntity == null) return;
            _mode = EditMode.Edit;
            ToggleEdit(true);
            ShowDetails(_editingEntity);
            LoadTicketSalesForCustomer(_editingEntity.CustomerId);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _mode = EditMode.None;
            _editingEntity = null;
            ToggleEdit(false);
            ClearDetails();
            ClearTicketSales();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _context.Dispose();
            _context = new TicketManagementContext();
            LoadData(txtSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;
            var selected = dgvCustomers.CurrentRow.DataBoundItem as Customer;
            if (selected == null) return;

            if (MessageBox.Show($"Xóa khách hàng {selected.CustomerCode}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var tracked = _context.Customers.FirstOrDefault(c => c.CustomerId == selected.CustomerId);
                if (tracked != null)
                {
                    bool hasSales = _context.TicketSales.Any(ts => ts.CustomerId == tracked.CustomerId);
                    if (hasSales)
                    {
                        MessageBox.Show("Không thể xóa: khách hàng đã có vé bán.");
                        return;
                    }
                    // Stub: no Remove method, so recreate list without tracked
                    var remaining = _context.Customers.Where(c => c != tracked).ToList();
                    // Simple rebuild (stub context not persistent)
                    _context.Customers.AddRange(remaining);
                    LoadData(txtSearch.Text);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_mode == EditMode.None) return;
            if (!ValidateInputs(out string err))
            {
                MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _editingEntity.CustomerCode = txtCustomerCode.Text.Trim();
            _editingEntity.FullName = txtFullName.Text.Trim();
            _editingEntity.Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim();

            // Fields removed from UI are defaulted
            // Keep existing Email if editing; new entries have null
            if (_mode == EditMode.Add)
                _editingEntity.Email = null; // Or set if later adding email field

            _editingEntity.Gender = null;
            _editingEntity.DateOfBirth = null;
            _editingEntity.Address = null;
            _editingEntity.IsActive = true;

            var now = DateTime.UtcNow;

            if (_mode == EditMode.Add)
            {
                _editingEntity.CreatedAt = now;
                _context.Customers.Add(_editingEntity);
            }
            else
            {
                _editingEntity.UpdatedAt = now; // stub: nothing else
            }

            try
            {
                _context.SaveChanges();
                int savedId = _editingEntity.CustomerId;
                _mode = EditMode.None;
                _editingEntity = null;
                ToggleEdit(false);
                LoadData(txtSearch.Text);

                var row = dgvCustomers.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => (r.DataBoundItem as Customer)?.CustomerId == savedId);
                if (row != null)
                {
                    row.Selected = true;
                    dgvCustomers.CurrentCell = row.Cells[0];
                    LoadTicketSalesForCustomer(savedId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message, "Error");
            }
        }

        private bool ValidateInputs(out string error)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerCode.Text))
            {
                error = "Mã khách hàng bắt buộc.";
                return false;
            }
            if (txtCustomerCode.Text.Length > 20)
            {
                error = "Mã KH tối đa 20 ký tự.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                error = "Họ tên bắt buộc.";
                return false;
            }
            string code = txtCustomerCode.Text.Trim();
            bool exists = _context.Customers.Any(c =>
                c.CustomerCode == code &&
                (_mode == EditMode.Add || (_mode == EditMode.Edit && c.CustomerId != _editingEntity.CustomerId)));
            if (exists)
            {
                error = "Mã khách hàng đã tồn tại.";
                return false;
            }
            error = null;
            return true;
        }

        private void ToggleEdit(bool editing)
        {
            txtCustomerCode.Enabled = editing && _mode == EditMode.Add;
            txtFullName.Enabled = editing;
            txtPhone.Enabled = editing;

            btnSave.Enabled = editing;
            btnCancel.Enabled = editing;

            btnAdd.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvCustomers.CurrentRow != null;
            btnDelete.Enabled = !editing && dgvCustomers.CurrentRow != null;
            btnReload.Enabled = !editing;
            btnSearch.Enabled = !editing;
            txtSearch.Enabled = !editing;
            dgvCustomers.Enabled = !editing;

            if (dgvTicketSales != null)
                dgvTicketSales.Enabled = !editing;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedCustomer = dgvCustomers.Rows[e.RowIndex].DataBoundItem as Customer;
                if (selectedCustomer == null) return;

                if (SelectionMode)
                {
                    SelectedCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == selectedCustomer.CustomerId);
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                _editingEntity = _context.Customers.FirstOrDefault(x => x.CustomerId == selectedCustomer.CustomerId);
                if (_editingEntity != null)
                {
                    ShowDetails(_editingEntity);
                    LoadTicketSalesForCustomer(_editingEntity.CustomerId);
                    ToggleEdit(true);
                    _mode = EditMode.Edit;
                }
            }
        }

        private void dgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var customer = dgvCustomers.Rows[e.RowIndex].DataBoundItem as Customer;
            if (customer == null) return;

            if (dgvCustomers.Columns[e.ColumnIndex].Name == "TicketCount")
            {
                if (_ticketStat.TryGetValue(customer.CustomerId, out var stat))
                    e.Value = stat.Count;
                else
                    e.Value = 0;
            }
            else if (dgvCustomers.Columns[e.ColumnIndex].Name == "TotalSpent")
            {
                if (_ticketStat.TryGetValue(customer.CustomerId, out var stat))
                    e.Value = stat.Total;
                else
                    e.Value = 0m;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosing(e);
        }
    }
}