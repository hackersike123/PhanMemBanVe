using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhanMemBanVe.DAL.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required, StringLength(20)]
        [Index("IX_CustomerCode", IsUnique = true)]
        public string CustomerCode { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        [Index("IX_CustomerPhone")]
        public string Phone { get; set; }

        [StringLength(255)]
        [Index("IX_CustomerEmail")]
        public string Email { get; set; }

        public byte? Gender { get; set; }          // 0=Unknown,1=Male,2=Female
        public DateTime? DateOfBirth { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<TicketSale> TicketSales { get; set; } = new HashSet<TicketSale>();
    }
}