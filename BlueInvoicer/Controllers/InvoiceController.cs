using BlueInvoicer.Models;
using BlueInvoicer.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BlueInvoicer.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create(int id)
        {
            var client = _context.Clients.Single(c => c.ClientId == id);

            return View(client);
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceFormViewModel viewModel)
        {
            //if(!ModelState.IsValid)
            //    return View("Create", viewModel);

            var prevInvoices = _context.Invoices.Count(i => i.ClientId == viewModel.ClientId);
            var clientName = _context.Clients.Single(c => c.ClientId == viewModel.ClientId);

            var invoice = new Invoice
            {
                ClientId = viewModel.ClientId,
                InvoiceDate = DateTime.Today,
                InvoiceNumber = clientName.ClientName.Substring(0, 3) + (++prevInvoices).ToString().PadLeft(3, '0')
            };

            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        public ActionResult Settings()
        {
            throw new System.NotImplementedException();
        }
    }
}