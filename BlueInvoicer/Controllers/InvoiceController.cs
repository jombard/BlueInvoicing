using BlueInvoicer.Models;
using BlueInvoicer.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BlueInvoicer.Controllers
{
    public class InvoiceController : Controller
    {
        private ApplicationDbContext _context;

        public InvoiceController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new InvoiceFormViewModel
            {
                Clients = _context.Clients.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Settings()
        {
            throw new System.NotImplementedException();
        }
    }
}