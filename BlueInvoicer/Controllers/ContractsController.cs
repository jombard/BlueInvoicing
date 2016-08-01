using BlueInvoicer.Models;
using BlueInvoicer.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BlueInvoicer.Controllers
{
    public class ContractsController : Controller
    {
        private ApplicationDbContext _context;

        public ContractsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create(int id)
        {
            var viewModel = new ContractsFormViewModel
            {
                Heading = "Add a new contract"
            };

            return View("ContractForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("ContractForm", viewModel);

            var contract = new Contract
            {
                Name = viewModel.Name,
                Rate = viewModel.Rate
            };

            //_context.Contracts.Add(contract);
            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ContractsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("ContractForm", viewModel);

            var client = _context.Clients.Single(c => c.ClientId == viewModel.Id);

            //client.ClientName = viewModel.Name;
            //client.Address = viewModel.Address;
            //client.ContactEmail = viewModel.Email;
            //client.InvoiceEmail = viewModel.InvoiceEmail;

            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }
    }
}