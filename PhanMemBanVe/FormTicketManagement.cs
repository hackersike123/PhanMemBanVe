using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemBanVe.Models;
using PhanMemBanVe.Data; // added

namespace PhanMemBanVe
{
    public partial class frmTicketManagement : Form
    {
        private enum SeatState { Available, Selected, Sold }

        private decimal totalPrice = 0;
        private readonly TicketManagementContext _context = new TicketManagementContext();
        private Customer _selectedCustomer;

        // Centralized colors
        private readonly Color _colorAvailable = Color.White;
        private readonly Color _colorSelected = Color.Gold;
        private readonly Color _colorSold = Color.Gray;

        public frmTicketManagement()
        {
            InitializeComponent();
            btnExit.Click += (s, e) => this.Close();
            btnCancel.Click += BtnCancel_Click;
            txtTotal.Enabled = false;
            btnBuyTicket.Click += BtnBuyTicket_Click;
            btnAddArea.Click += BtnAddArea_Click;
            txtFullName.DoubleClick += TxtFullName_DoubleClick;

            EnsureDefaultAreas();
        }

        private void EnsureDefaultAreas()
        {
            if (cboArea.Items.Count == 0)
            {
                cboArea.Items.AddRange(new object[]
                {
                    "Standard",
                    "Deluxe",
                    "Premium",
                    "VIP"
                });
            }
        }

        private void TxtFullName_DoubleClick(object sender, EventArgs e)
        {
            using (var picker = new FormCustomers { SelectionMode = true, StartPosition = FormStartPosition.CenterParent })
            {
                if (picker.ShowDialog(this) == DialogResult.OK && picker.SelectedCustomer != null)
                {
                    _selectedCustomer = picker.SelectedCustomer;
                    txtFullName.Text = _selectedCustomer.FullName;
                    txtPhone.Text = _selectedCustomer.Phone;
                    if (_selectedCustomer.Gender.HasValue)
                    {
                        if (_selectedCustomer.Gender == 1) radMale.Checked = true;
                        else if (_selectedCustomer.Gender == 2) radFemale.Checked = true;
                    }
                }
            }
        }

        private bool ValidatePurchase(out string error)
        {
            // Determine selected seats from state (not only totalPrice)
            var hasSelectedSeat = grbManHinh.Controls
                .OfType<Button>()
                .Any(b => b.Tag is SeatState st && st == SeatState.Selected);

            if (!hasSelectedSeat)
            {
                error = "Please select at least one seat.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                error = "Full Name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                error = "Phone is required.";
                return false;
            }
            if (!radMale.Checked && !radFemale.Checked)
            {
                error = "Please choose a gender.";
                return false;
            }
            if (cboArea.SelectedIndex < 0)
            {
                error = "Please select an Area.";
                return false;
            }
            error = null;
            return true;
        }

        private void frmTicketManagement_Load(object sender, EventArgs e)
        {
            // Attach handlers & initialize seat state
            foreach (var btn in grbManHinh.Controls.OfType<Button>())
            {
                if (btn == btnBuyTicket || btn == btnCancel || btn == btnExit) continue;
                btn.Click -= btnChooseSeats_Click;
                btn.Click += btnChooseSeats_Click;

                if (btn.Tag == null)
                {
                    btn.Tag = SeatState.Available;
                    btn.BackColor = _colorAvailable;
                    btn.Enabled = true;
                }
            }

            // (Optional) If you later want to mark already sold seats from DB
            // LoadSoldSeatsFromDatabase();
            UpdateTotalFromSelection();
        }

        private void BtnBuyTicket_Click(object sender, EventArgs e)
        {
            if (!ValidatePurchase(out string error))
            {
                MessageBox.Show(error, "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (_selectedCustomer == null)
            {
                _selectedCustomer = _context.Customers.FirstOrDefault(c => c.Phone == phone);
                if (_selectedCustomer == null)
                {
                    _selectedCustomer = new Customer
                    {
                        CustomerCode = "C" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff"),
                        FullName = name,
                        Phone = phone,
                        Gender = radMale.Checked ? (byte?)1 : radFemale.Checked ? (byte?)2 : null,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    };
                    _context.Customers.Add(_selectedCustomer);
                    _context.SaveChanges();
                }
            }
            else
            {
                var newGender = radMale.Checked ? (byte?)1 : radFemale.Checked ? (byte?)2 : null;
                if (_selectedCustomer.Gender != newGender)
                {
                    _selectedCustomer.Gender = newGender;
                    _context.SaveChanges();
                }
            }

            var selectedButtons = grbManHinh.Controls.OfType<Button>()
                .Where(b => b.Tag is SeatState st && st == SeatState.Selected)
                .ToList();

            // Capture total BEFORE we reset selection state
            decimal purchaseTotal = selectedButtons
                .Select(b => GetServicePrice(int.Parse(b.Text)))
                .Sum();

            DateTime saleTime = DateTime.Now; // local time consistent with report

            foreach (var seatBtn in selectedButtons)
            {
                int seatNumber = int.Parse(seatBtn.Text);
                decimal price = GetServicePrice(seatNumber);
                var sale = new TicketSale
                {
                    TicketCode = $"T{DateTime.UtcNow:yyyyMMddHHmmssfff}_{seatNumber}",
                    CustomerId = _selectedCustomer.CustomerId,
                    SeatNumber = seatNumber,
                    AreaName = cboArea.Text,
                    Price = price,
                    SaleDate = saleTime
                };
                _context.TicketSales.Add(sale);

                seatBtn.Tag = SeatState.Sold;
                seatBtn.BackColor = _colorSold;
                seatBtn.Enabled = false;
            }

            _context.SaveChanges();

            // Clear selection count & total AFTER saving
            UpdateTotalFromSelection();

            // Show the correct total (purchaseTotal, not the now reset totalPrice)
            dgvBill.Rows.Add(name, phone, purchaseTotal.ToString("C"));

            // Reset inputs
            txtFullName.Clear();
            txtPhone.Clear();
            radMale.Checked = false;
            radFemale.Checked = false;
            cboArea.SelectedIndex = -1;
            _selectedCustomer = null;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Revert only currently selected seats
            foreach (var btn in grbManHinh.Controls.OfType<Button>())
            {
                if (btn.Tag is SeatState st && st == SeatState.Selected)
                {
                    btn.Tag = SeatState.Available;
                    btn.BackColor = _colorAvailable;
                }
            }
            UpdateTotalFromSelection();
        }

        private void btnChooseSeats_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton == null) return;

            var state = clickedButton.Tag as SeatState? ?? SeatState.Available;

            if (state == SeatState.Sold)
            {
                // Ignore clicks on sold seats (should already be disabled)
                return;
            }

            if (state == SeatState.Available)
            {
                clickedButton.Tag = SeatState.Selected;
                clickedButton.BackColor = _colorSelected;
            }
            else if (state == SeatState.Selected)
            {
                clickedButton.Tag = SeatState.Available;
                clickedButton.BackColor = _colorAvailable;
            }

            UpdateTotalFromSelection();
        }

        private void UpdateTotalFromSelection()
        {
            totalPrice = grbManHinh.Controls.OfType<Button>()
                .Where(b => b.Tag is SeatState st && st == SeatState.Selected)
                .Select(b => GetServicePrice(int.Parse(b.Text)))
                .Sum();

            txtTotal.Text = totalPrice.ToString("C");
        }

        private decimal GetServicePrice(int seatNumber)
        {
            if (seatNumber >= 1 && seatNumber <= 5) return 80000;
            if (seatNumber >= 6 && seatNumber <= 10) return 90000;
            if (seatNumber >= 11 && seatNumber <= 15) return 100000;
            return 110000;
        }

        // Add area from current combo text
        private void BtnAddArea_Click(object sender, EventArgs e)
        {
            string newArea = (cboArea.Text ?? string.Empty).Trim();

            if (string.IsNullOrEmpty(newArea))
            {
                MessageBox.Show("Enter area name first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboArea.Focus();
                return;
            }

            bool exists = cboArea.Items.Cast<object>()
                .Any(i => string.Equals(i.ToString(), newArea, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                MessageBox.Show("Area already exists.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboArea.SelectedItem = cboArea.Items.Cast<object>()
                    .First(i => string.Equals(i.ToString(), newArea, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                cboArea.Items.Add(newArea);
                cboArea.SelectedItem = newArea;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context.Dispose();
            base.OnFormClosing(e);
        }
    }
}
