using Invoices.BLL.Models.RequestDTO;
using Invoices.BLL.Models.ResponseDTO;
using Invoices.DAL.Contracts;
using Invoices.DAL.Data;
using Invoices.DAL.Data.Models;
using Invoices.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.BLL.Services.Client
{
    public class ServiceInvoice : IServiceInvoice

        
    {
        private readonly ApplicationDbContext _appDbContext;
        public readonly IInvoiceHDRRepository _invoiceRepository;
        public readonly IItemsDTLRepository _itemsDTLRepository;

        public ServiceInvoice(IInvoiceHDRRepository rnvoiceHDRRepository, IItemsDTLRepository itemsDTLRepository, ApplicationDbContext appDbContext)
        {
            _invoiceRepository = rnvoiceHDRRepository;
            _itemsDTLRepository = itemsDTLRepository;
             _appDbContext = appDbContext;
    }




        //public InvoiceHDR GetByInvoiceNum(int InvoiceNumber)
        //{
        //    try
        //    {
        //        if (InvoiceNumber != 0)
        //        {
        //            return _invoiceRepository.GetByInvoiceNum(InvoiceNumber);
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public IEnumerable<InvoicesVM> GetAllInvoice()
        {
            try
            {
                return _invoiceRepository.GetAll().Select(e => new InvoicesVM
                {
                    InvoiceId = e.InvoiceId,
                    InvoiceNum = e.InvoiceNum,
                    Customer = e.Customer,
                    Description = e.Description,
                    InvoiceDate = e.InvoiceDate,
                    PaymentMethod = e.PaymentMethod,
                    ItemsCount = e.ItemsDTLs.Count()
                }).ToList(); ;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task Create(InvoiceCreateVM createVM)
        {
            try
            {
                if (createVM != null)
                {

                     await _invoiceRepository.Create(new InvoiceHDR
                    {
                        InvoiceDate = createVM.InvoiceDate,
                        InvoiceNum = createVM.InvoiceNumber,
                        PaymentMethod = createVM.PaymentMethod,
                        Customer = createVM.Customer,
                        Description = createVM.Description
                    });


                    var currentInvoice = await _invoiceRepository.GetByInvoiceNum(createVM.InvoiceNumber);
                    //var currentInvoice = await _invoiceRepository.GetByInvoiceNum(852);
                    //var currentInvoice = await _invoiceRepository.where(e => e.InvoiceNum == createVM.InvoiceNumber).FindOrDefaultAsync();

                    if (currentInvoice != null)
                    {
                        for (int i = 0; i < createVM.ItemCode.Count; i++)
                        {
                            await _itemsDTLRepository.Create(new ItemsDTL
                            {
                                ItemCode = createVM.ItemCode[i],
                                InvoiceId = currentInvoice.InvoiceId,
                                Price = createVM.Price[i],
                                Qty = createVM.Qty[i],
                                ItemName = createVM.ItemName[i]
                            });

                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invoice with number {createVM.InvoiceNumber} does not exist in the database");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public InvoiceEditVM Edit(int? id)
        {
            try
            {
                if (id != null)
                {
                    var invoiceExists = _invoiceRepository.GetAll().Select(e => new InvoiceEditVM
                    {
                        InvoiceId = e.InvoiceId,
                        Customer = e.Customer,
                        Description = e.Description,
                        InvoiceDate = e.InvoiceDate,
                        InvoiceNumber = e.InvoiceNum,
                        PaymentMethod = e.PaymentMethod,
                        InvoiceItems = e.ItemsDTLs
                    }).SingleOrDefault(e => e.InvoiceId ==id);
                    if (invoiceExists != null)
                    {
                        return invoiceExists;
                    }


                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
