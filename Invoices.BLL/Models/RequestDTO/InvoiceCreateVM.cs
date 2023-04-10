namespace Invoices.BLL.Models.RequestDTO
{
    public class InvoiceCreateVM
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Customer { get; set; } = null!;
        public byte PaymentMethod { get; set; }
        public string? Description { get; set; }

        public List<int> ItemCode { get; set; } = null!;
        public List<string> ItemName { get; set; } = null!;
        public List<int> Qty { get; set; } = null!;
        public List<int> Price { get; set; } = null!;
    }
}
