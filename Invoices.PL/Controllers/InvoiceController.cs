using Invoices.BLL.Models.RequestDTO;
using Invoices.BLL.Services.Client;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.PL.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IServiceInvoice _serviceInvoice;
        public InvoiceController(IServiceInvoice serviceInvoice)
        {
            _serviceInvoice = serviceInvoice;
        }

       

       

        public async Task<IActionResult> Index()
        {
            
            return View(_serviceInvoice.GetAllInvoice());
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceCreateVM createVM)
        {
            
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));

           await _serviceInvoice.Create(createVM);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var invoiceExists = _serviceInvoice.Edit(id);

            if (invoiceExists == null) return NotFound();

            return PartialView("_EditView", invoiceExists);
        }

        




    }
}