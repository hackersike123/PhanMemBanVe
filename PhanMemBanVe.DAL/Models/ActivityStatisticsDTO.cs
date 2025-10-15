using System;

namespace PhanMemBanVe.DAL.Models
{
    public class ActivityStatisticsDTO
    {
        public string Period { get; set; }           // Ngày, Tuần, Tháng
        public int TotalTickets { get; set; }         // Tổng số vé
        public int TicketsSold { get; set; }          // Vé đã bán
        public int TicketsRefunded { get; set; }      // Vé đã hoàn
        public decimal TotalRevenue { get; set; }     // Tổng doanh thu
        public decimal AveragePrice { get; set; }     // Giá trung bình
        public string TopArea { get; set; }           // Khu vực bán chạy nhất
        public int TopAreaCount { get; set; }         // Số lượng khu vực đó
    }
}
