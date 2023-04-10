using Invoices.DAL.Data.Models;

namespace Invoices.BLL.Models.ResponseDTO
{
    public class InvoiceEditVM
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public byte PaymentMethod { get; set; }
        public string Customer { get; set; } = null!;
        public string? Description { get; set; }

        public List<ItemsDTL> InvoiceItems { get; set; } = null!;
    }
}
