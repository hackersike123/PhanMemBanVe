using System;

namespace PhanMemBanVe.DAL.Models
{
    public class TicketSaleReportDTO
    {
        public string TicketCode { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime SaleDate { get; set; }
        public int SeatNumber { get; set; }
        public string AreaName { get; set; }
        public decimal Price { get; set; }
        public bool IsRefunded { get; set; }
    }
}