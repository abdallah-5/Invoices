using Invoices.DAL.Contracts;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Invoices.DAL.Repositories
{
    public class InvoiceHDRRepository : IInvoiceHDRRepository
    {
        private readonly ApplicationDbContext _context;
        public InvoiceHDRRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InvoiceHDR> Create(InvoiceHDR invoiceHDR)
        {
            try
            {
                if (invoiceHDR != null)
                {
                    var obj = _context.Add<InvoiceHDR>(invoiceHDR);
                    await _context.SaveChangesAsync();
                    return obj.Entity;
                }
                else
                {
                    return null!;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(InvoiceHDR invoiceHDR)
        {
            try
            {
                if (invoiceHDR != null)
                {
                    var obj = _context.Remove(invoiceHDR);
                    if (obj != null)
                    {
                        _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<InvoiceHDR> GetAll()
        {
            try
            {
                var obj = _context.InvoiceHDRs.Include(e => e.ItemsDTLs).ToList();
                if (obj != null) return obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<InvoiceHDR> GetByInvoiceNum(int InvoiceNumber)
        {
            try
            {
                return await _context.InvoiceHDRs.FirstOrDefaultAsync(e => e.InvoiceNum == InvoiceNumber);

            }
            catch (Exception)
            {
                throw;
            }
        }


        public InvoiceHDR GetById(int? Id)
        {
            try
            {
                var Obj = _context.InvoiceHDRs.FirstOrDefault(x => x.InvoiceId == Id);
                if (Obj != null) return Obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }


      

        public void Update(InvoiceHDR invoiceHDR)
        {
            try
            {
                if (invoiceHDR != null)
                {
                    var obj = _context.Update(invoiceHDR);
                    if (obj != null) _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
