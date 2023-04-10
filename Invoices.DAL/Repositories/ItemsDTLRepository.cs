using Invoices.DAL.Contracts;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.DAL.Repositories
{
    public class ItemsDTLRepository : IItemsDTLRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemsDTLRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemsDTL> Create(ItemsDTL itemsDTL)
        {
            try
            {
                if (itemsDTL != null)
                {
                    var obj = _context.Add<ItemsDTL>(itemsDTL);
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

        public void Delete(ItemsDTL itemsDTL)
        {
            try
            {
                if (itemsDTL != null)
                {
                    var obj = _context.Remove(itemsDTL);
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

        public IEnumerable<ItemsDTL> GetAll()
        {
            try
            {
                var obj = _context.ItemsDTLs.Include(e => e.InvoiceHDR).ToList();
                if (obj != null) return obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ItemsDTL GetById(int? Id)
        {
            try
            {
                var Obj = _context.ItemsDTLs.FirstOrDefault(x => x.ItemCode == Id);
                if (Obj != null) return Obj;
                else return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(ItemsDTL itemsDTL)
        {
            try
            {
                if (itemsDTL != null)
                {
                    var obj = _context.Update(itemsDTL);
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
