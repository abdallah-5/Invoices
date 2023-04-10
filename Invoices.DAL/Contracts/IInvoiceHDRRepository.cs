using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DAL.Contracts
{
    public interface IInvoiceHDRRepository : IRepository<InvoiceHDR>
    {
        public Task<InvoiceHDR> GetByInvoiceNum(int InvoiceNumber);

       
    }
}