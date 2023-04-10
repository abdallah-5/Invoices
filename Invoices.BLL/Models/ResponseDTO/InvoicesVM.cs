namespace Invoices.BLL.Models.ResponseDTO
{
    public class InvoicesVM
    {
        public int InvoiceId { get; set; }
        public int InvoiceNum { get; set; }
        public DateTime InvoiceDate { get; set; }
        public byte PaymentMethod { get; set; }
        public string Customer { get; set; } = null!;
        public string? Description { get; set; }
        public int ItemsCount { get; set; }
    }
}
