using BlueInvoicer.Models;
using BlueInvoicer.ViewModels;
using System.Web.Mvc;

namespace BlueInvoicer.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var allClients = _context.Clients;

            return View(allClients);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return View("Create", viewModel);

            var client = new Client
            {
                ClientName = viewModel.Name,
                Address = viewModel.Address,
                ContactEmail = viewModel.Email,
                InvoiceEmail = viewModel.InvoiceEmail
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }
    }
}