using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PhanMemBanVe.DAL.Data;
using PhanMemBanVe.DAL.Models;
using System.Data.Entity;
using System.Globalization;

namespace PhanMemBanVe.GUI
{
    public partial class FormActivityStatistics : Form
    {
        public FormActivityStatistics()
        {
            InitializeComponent();
            btnRefresh.Click += BtnRefresh_Click;
        }

        private void FormActivityStatistics_Load(object sender, EventArgs e)
        {
            // Mặc định: 30 ngày gần đây, nhóm theo ngày
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            cboGroupBy.SelectedIndex = 0; // Ngày

            LoadStatistics();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date.AddDays(1).AddTicks(-1);

                if (fromDate > toDate)
                {
                    MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var ctx = new TicketManagementContext())
                {
                    ctx.Database.Initialize(false);

                    var tickets = ctx.TicketSales
                        .Include(t => t.Customer)
                        .Where(t => t.SaleDate >= fromDate && t.SaleDate <= toDate)
                        .ToList();

                    // Load tổng quan
                    LoadOverviewTab(tickets);

                    // Load theo thời gian
                    LoadPeriodTab(tickets);

                    // Load theo khu vực
                    LoadAreaTab(tickets);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadOverviewTab(List<TicketSale> tickets)
        {
            int totalSold = tickets.Count(t => !t.IsRefunded);
            int totalRefunded = tickets.Count(t => t.IsRefunded);
            decimal totalRevenue = tickets.Where(t => !t.IsRefunded).Sum(t => t.Price ?? 0);
            decimal avgPrice = totalSold > 0 ? totalRevenue / totalSold : 0;

            lblTotalValue.Text = totalSold.ToString("N0");
            lblRefundedValue.Text = totalRefunded.ToString("N0");
            lblRevenueValue.Text = totalRevenue.ToString("N0") + " VNĐ";
            lblAvgPriceValue.Text = avgPrice.ToString("N0") + " VNĐ";
        }

        private void LoadPeriodTab(List<TicketSale> tickets)
        {
            string groupBy = cboGroupBy.SelectedItem?.ToString() ?? "Ngày";
            var groupedData = new List<ActivityStatisticsDTO>();

            if (groupBy == "Ngày")
            {
                groupedData = tickets
                    .GroupBy(t => t.SaleDate.Date)
                    .Select(g => new ActivityStatisticsDTO
                    {
                        Period = g.Key.ToString("dd/MM/yyyy"),
                        TotalTickets = g.Count(),
                        TicketsSold = g.Count(t => !t.IsRefunded),
                        TicketsRefunded = g.Count(t => t.IsRefunded),
                        TotalRevenue = g.Where(t => !t.IsRefunded).Sum(t => t.Price ?? 0),
                        AveragePrice = g.Where(t => !t.IsRefunded).Any() 
                            ? g.Where(t => !t.IsRefunded).Average(t => t.Price ?? 0) 
                            : 0
                    })
                    .OrderBy(x => x.Period)
                    .ToList();
            }
            else if (groupBy == "Tuần")
            {
                var cal = CultureInfo.CurrentCulture.Calendar;
                var weekRule = CalendarWeekRule.FirstFourDayWeek;
                var firstDayOfWeek = DayOfWeek.Monday;

                groupedData = tickets
                    .GroupBy(t => new
                    {
                        Year = t.SaleDate.Year,
                        Week = cal.GetWeekOfYear(t.SaleDate, weekRule, firstDayOfWeek)
                    })
                    .Select(g => new ActivityStatisticsDTO
                    {
                        Period = $"Tuần {g.Key.Week}/{g.Key.Year}",
                        TotalTickets = g.Count(),
                        TicketsSold = g.Count(t => !t.IsRefunded),
                        TicketsRefunded = g.Count(t => t.IsRefunded),
                        TotalRevenue = g.Where(t => !t.IsRefunded).Sum(t => t.Price ?? 0),
                        AveragePrice = g.Where(t => !t.IsRefunded).Any()
                            ? g.Where(t => !t.IsRefunded).Average(t => t.Price ?? 0)
                            : 0
                    })
                    .OrderBy(x => x.Period)
                    .ToList();
            }
            else // Tháng
            {
                groupedData = tickets
                    .GroupBy(t => new { t.SaleDate.Year, t.SaleDate.Month })
                    .Select(g => new ActivityStatisticsDTO
                    {
                        Period = $"{g.Key.Month:00}/{g.Key.Year}",
                        TotalTickets = g.Count(),
                        TicketsSold = g.Count(t => !t.IsRefunded),
                        TicketsRefunded = g.Count(t => t.IsRefunded),
                        TotalRevenue = g.Where(t => !t.IsRefunded).Sum(t => t.Price ?? 0),
                        AveragePrice = g.Where(t => !t.IsRefunded).Any()
                            ? g.Where(t => !t.IsRefunded).Average(t => t.Price ?? 0)
                            : 0
                    })
                    .OrderBy(x => x.Period)
                    .ToList();
            }

            // Temporarily disable AutoSizeColumnsMode to set Width
            var originalMode = dgvPeriod.AutoSizeColumnsMode;
            dgvPeriod.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            try
            {
                // Bind to DataGridView
                dgvPeriod.DataSource = groupedData;

                // Configure columns - check for null first
                if (dgvPeriod.Columns.Contains("Period") && dgvPeriod.Columns["Period"] != null)
                {
                    dgvPeriod.Columns["Period"].HeaderText = "Thời gian";
                    dgvPeriod.Columns["Period"].Width = 150;
                }

                if (dgvPeriod.Columns.Contains("TotalTickets") && dgvPeriod.Columns["TotalTickets"] != null)
                {
                    dgvPeriod.Columns["TotalTickets"].HeaderText = "Tổng vé";
                    dgvPeriod.Columns["TotalTickets"].Width = 100;
                }

                if (dgvPeriod.Columns.Contains("TicketsSold") && dgvPeriod.Columns["TicketsSold"] != null)
                {
                    dgvPeriod.Columns["TicketsSold"].HeaderText = "Vé bán";
                    dgvPeriod.Columns["TicketsSold"].Width = 100;
                }

                if (dgvPeriod.Columns.Contains("TicketsRefunded") && dgvPeriod.Columns["TicketssRefunded"] != null)
                {
                    dgvPeriod.Columns["TicketsRefunded"].HeaderText = "Vé hoàn";
                    dgvPeriod.Columns["TicketsRefunded"].Width = 100;
                }

                if (dgvPeriod.Columns.Contains("TotalRevenue") && dgvPeriod.Columns["TotalRevenue"] != null)
                {
                    dgvPeriod.Columns["TotalRevenue"].HeaderText = "Doanh thu";
                    dgvPeriod.Columns["TotalRevenue"].DefaultCellStyle.Format = "N0";
                    dgvPeriod.Columns["TotalRevenue"].Width = 150;
                }

                if (dgvPeriod.Columns.Contains("AveragePrice") && dgvPeriod.Columns["AveragePrice"] != null)
                {
                    dgvPeriod.Columns["AveragePrice"].HeaderText = "Giá TB";
                    dgvPeriod.Columns["AveragePrice"].DefaultCellStyle.Format = "N0";
                    dgvPeriod.Columns["AveragePrice"].Width = 120;
                }

                // Hide unused columns
                if (dgvPeriod.Columns.Contains("TopArea") && dgvPeriod.Columns["TopArea"] != null)
                    dgvPeriod.Columns["TopArea"].Visible = false;
                if (dgvPeriod.Columns.Contains("TopAreaCount") && dgvPeriod.Columns["TopAreaCount"] != null)
                    dgvPeriod.Columns["TopAreaCount"].Visible = false;
            }
            finally
            {
                // Restore AutoSizeColumnsMode
                dgvPeriod.AutoSizeColumnsMode = originalMode;
            }
        }

        private void LoadAreaTab(List<TicketSale> tickets)
        {
            var soldTickets = tickets.Where(t => !t.IsRefunded).ToList();
            int totalSold = soldTickets.Count;
            decimal totalRevenue = soldTickets.Sum(t => t.Price ?? 0);

            var areaData = soldTickets
                .GroupBy(t => t.AreaName ?? "Không xác định")
                .Select(g => new AreaStatisticsDTO
                {
                    AreaName = g.Key,
                    TicketCount = g.Count(),
                    TotalRevenue = g.Sum(t => t.Price ?? 0),
                    AveragePrice = g.Average(t => t.Price ?? 0),
                    Percentage = totalSold > 0 ? (decimal)g.Count() / totalSold * 100 : 0
                })
                .OrderByDescending(x => x.TicketCount)
                .ToList();

            // Temporarily disable AutoSizeColumnsMode to set Width
            var originalMode = dgvArea.AutoSizeColumnsMode;
            dgvArea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            try
            {
                dgvArea.DataSource = areaData;

                // Configure columns - check for null first
                if (dgvArea.Columns.Contains("AreaName") && dgvArea.Columns["AreaName"] != null)
                {
                    dgvArea.Columns["AreaName"].HeaderText = "Khu vực";
                    dgvArea.Columns["AreaName"].Width = 200;
                }

                if (dgvArea.Columns.Contains("TicketCount") && dgvArea.Columns["TicketCount"] != null)
                {
                    dgvArea.Columns["TicketCount"].HeaderText = "Số vé";
                    dgvArea.Columns["TicketCount"].Width = 100;
                }

                if (dgvArea.Columns.Contains("TotalRevenue") && dgvArea.Columns["TotalRevenue"] != null)
                {
                    dgvArea.Columns["TotalRevenue"].HeaderText = "Doanh thu";
                    dgvArea.Columns["TotalRevenue"].DefaultCellStyle.Format = "N0";
                    dgvArea.Columns["TotalRevenue"].Width = 150;
                }

                if (dgvArea.Columns.Contains("AveragePrice") && dgvArea.Columns["AveragePrice"] != null)
                {
                    dgvArea.Columns["AveragePrice"].HeaderText = "Giá trung bình";
                    dgvArea.Columns["AveragePrice"].DefaultCellStyle.Format = "N0";
                    dgvArea.Columns["AveragePrice"].Width = 120;
                }

                if (dgvArea.Columns.Contains("Percentage") && dgvArea.Columns["Percentage"] != null)
                {
                    dgvArea.Columns["Percentage"].HeaderText = "Tỷ lệ %";
                    dgvArea.Columns["Percentage"].DefaultCellStyle.Format = "N2";
                    dgvArea.Columns["Percentage"].Width = 100;
                }
            }
            finally
            {
                // Restore AutoSizeColumnsMode
                dgvArea.AutoSizeColumnsMode = originalMode;
            }
        }
    }
}
