using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.DAL.Data.Models
{
    public class ItemsDTL
    {
        [Key]
        public int ItemId { get; set; }
        public int ItemCode { get; set; }
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual InvoiceHDR InvoiceHDR { get; set; } = null!;
        [Required, MaxLength(150)]
        public string ItemName { get; set; } = null!;
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
