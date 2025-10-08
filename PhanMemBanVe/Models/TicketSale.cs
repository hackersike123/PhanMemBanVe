using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemBanVe.Models
{
    [Table("TicketSales")]
    public class TicketSale
    {
        [Key]
        public int TicketSaleId { get; set; }

        [Required, StringLength(50)]
        [Index("IX_TicketCode", IsUnique = true)]
        public string TicketCode { get; set; }

        // FK -> Customer
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        // Use local time to align with reporting filters (DateTimePicker uses local)
        public DateTime SaleDate { get; set; } = DateTime.Now;

        // Optional extra fields (adjust / remove if not needed)
        public int? SeatNumber { get; set; }

        [StringLength(100)]
        public string AreaName { get; set; }

        public decimal? Price { get; set; }

        public bool IsRefunded { get; set; }
    }
}