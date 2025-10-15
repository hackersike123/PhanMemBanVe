using System;

namespace PhanMemBanVe.DAL.Models
{
    public class AreaStatisticsDTO
    {
        public string AreaName { get; set; }
        public int TicketCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal Percentage { get; set; }  // % so với tổng
    }
}
