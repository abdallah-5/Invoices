using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<InvoiceHDR> InvoiceHDRs { get; set; }
        public virtual DbSet<ItemsDTL> ItemsDTLs { get; set; }
    }
}
