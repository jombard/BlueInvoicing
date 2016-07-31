using BlueInvoicer.Models;
using BlueInvoicer.ViewModels;
using System.Linq;
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
            var viewModel = new ClientFormViewModel
            {
                Heading = "Add a new client"
            };

            return View("ClientForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var client = _context.Clients.Single(c => c.ClientId == id);

            var viewModel = new ClientFormViewModel()
            {
                Id = client.ClientId,
                Name = client.ClientName,
                Address = client.Address,
                Email = client.ContactEmail,
                InvoiceEmail = client.InvoiceEmail,
                Heading = "Edit a client"
            };

            return View("ClientForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return View("ClientForm", viewModel);

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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ClientFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return View("ClientForm", viewModel);

            var client = _context.Clients.Single(c => c.ClientId == viewModel.Id);

            client.ClientName = viewModel.Name;
            client.Address = viewModel.Address;
            client.ContactEmail = viewModel.Email;
            client.InvoiceEmail = viewModel.InvoiceEmail;

            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }
    }
}