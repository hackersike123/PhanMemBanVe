using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PhanMemBanVe.DAL.Models;
using System.Data.Entity;
using PhanMemBanVe.GUI.Utils;
using PhanMemBanVe.DAL.Data;

namespace PhanMemBanVe.GUI
{
    public partial class FormTicketSalesReport : Form
    {
        private const string ReportFileName = "TicketSalesReport.rdlc";
        private const string DataSetName = "TicketSalesDataSet";

        public FormTicketSalesReport()
        {
            InitializeComponent();
        }

        private void FormTicketSalesReport_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;
            LoadReport();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            Cursor previous = Cursor;
            Cursor = Cursors.WaitCursor;
            try
            {
                DateTime fromDateRaw = dtpFrom.Value.Date;
                DateTime toDateRaw = dtpTo.Value.Date;
                if (fromDateRaw > toDateRaw)
                {
                    var tmp = fromDateRaw;
                    fromDateRaw = toDateRaw;
                    toDateRaw = tmp;
                    dtpFrom.Value = fromDateRaw;
                    dtpTo.Value = toDateRaw;
                }

                DateTime fromDate = fromDateRaw;
                DateTime toDate = toDateRaw.AddDays(1).AddTicks(-1);
                string areaFilter = txtArea.Text.Trim();

                string resolvedReportPath = ReportFileLocator.GetOrCopyToOutput(ReportFileName);
                if (string.IsNullOrWhiteSpace(resolvedReportPath) || !File.Exists(resolvedReportPath))
                {
                    throw new FileNotFoundException("Không tìm thấy file RDLC tại: " + resolvedReportPath);
                }

                List<TicketSaleReportDTO> data;
                using (var ctx = new TicketManagementContext())
                {
                    ctx.Database.Initialize(false);

                    var query = ctx.TicketSales
                        .Include(t => t.Customer)
                        .Where(t => t.SaleDate >= fromDate && t.SaleDate <= toDate);

                    if (!string.IsNullOrEmpty(areaFilter))
                        query = query.Where(t => t.AreaName != null && t.AreaName.Contains(areaFilter));

                    data = query
                        .OrderBy(t => t.SaleDate)
                        .AsEnumerable()
                        .Select(t => new TicketSaleReportDTO
                        {
                            TicketCode = t.TicketCode ?? "",
                            CustomerCode = t.Customer != null ? (t.Customer.CustomerCode ?? "") : "",
                            FullName = t.Customer != null ? (t.Customer.FullName ?? "") : "",
                            Phone = t.Customer != null ? (t.Customer.Phone ?? "") : "",
                            SaleDate = t.SaleDate,
                            SeatNumber = t.SeatNumber ?? 0,
                            AreaName = t.AreaName ?? "",
                            Price = t.IsRefunded ? 0m : (t.Price ?? 0m),
                            IsRefunded = t.IsRefunded
                        })
                        .ToList();
                }

                PrepareReportViewer(resolvedReportPath, data, fromDateRaw, toDateRaw, areaFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(BuildDetailedError(ex), "Lỗi tải báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = previous;
            }
        }

        private void PrepareReportViewer(string reportPath, List<TicketSaleReportDTO> data,
            DateTime fromDateRaw, DateTime toDateRaw, string areaFilter)
        {
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            using (var fs = new FileStream(reportPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                reportViewer1.LocalReport.LoadReportDefinition(fs);
            }

            reportViewer1.LocalReport.DataSources.Clear();
            var rds = new ReportDataSource(DataSetName, data);
            reportViewer1.LocalReport.DataSources.Add(rds);

            var parameters = new[]
            {
                new ReportParameter("DateFrom", fromDateRaw.ToString("o")),
                new ReportParameter("DateTo", toDateRaw.ToString("o")),
                new ReportParameter("Area", string.IsNullOrEmpty(areaFilter) ? "" : areaFilter)
            };

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }

        private string BuildDetailedError(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine(ex.GetType().FullName + ": " + ex.Message);
            var current = ex.InnerException;
            int level = 1;
            while (current != null)
            {
                sb.AppendLine("Inner[" + level + "] " + current.GetType().FullName + ": " + current.Message);
                current = current.InnerException;
                level++;
            }

            sb.AppendLine();
            sb.AppendLine("Gợi ý kiểm tra:");
            sb.AppendLine("1. Tên DataSet trong RDLC phải là '" + DataSetName + "'.");
            sb.AppendLine("2. Các field RDLC: TicketCode, CustomerCode, FullName, Phone, SaleDate, SeatNumber, AreaName, Price, IsRefunded.");
            sb.AppendLine("3. Kiểu tham số DateFrom/DateTo trong RDLC là DateTime (đang truyền ISO 8601).");
            sb.AppendLine("4. File RDLC đúng bản mới đã Copy to Output (Reports).");
            sb.AppendLine("5. Đã Clean + Rebuild để tránh cache RDLC cũ.");
            sb.AppendLine("6. Bảng TicketSales có Customer hợp lệ (không null).");

            return sb.ToString();
        }
    }
}
