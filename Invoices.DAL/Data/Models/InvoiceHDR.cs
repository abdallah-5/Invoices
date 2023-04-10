using System.ComponentModel.DataAnnotations;

namespace Invoices.DAL.Data.Models
{
    public class InvoiceHDR
    {
        [Key]
        public int InvoiceId { get; set; }
        public int InvoiceNum { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        public byte PaymentMethod { get; set; }
        [Required, MaxLength(150)]
        public string Customer { get; set; } = null!;
        [MaxLength(500)]
        public string? Description{ get; set; }

        public List<ItemsDTL> ItemsDTLs { get; set; } = null!;
    }
}
