using System;
using BlueInvoicer.Models;
using BlueInvoicer.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BlueInvoicer.Controllers
{
    public class ContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create(int id)
        {
            var clientName = _context.Clients.Single(c => c.ClientId == id).ClientName;
            var viewModel = new ContractsFormViewModel
            {
                Heading = "Add a new contract",
                ClientId = id,
                Client = clientName,
                RateTypes = _context.RateTypes.ToList()
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

            var client = _context.Clients.Single(c => c.ClientId == viewModel.ClientId);
            var rateType = _context.RateTypes.Single(r => r.Id == viewModel.RateType);
            var overtimeRateType = _context.RateTypes.Single(r => r.Id == viewModel.OvertimeRateType);

            var contract = new Contract
            {
                Client = client,
                Name = viewModel.Name,
                StartDate = DateTime.Parse(viewModel.StartDate),
                EndDate = DateTime.Parse(viewModel.EndDate),
                Rate = viewModel.Rate,
                RateType = rateType,
                OvertimeRate = viewModel.OvertimeRate,
                OvertimeRateType = overtimeRateType
            };

            _context.Contracts.Add(contract);
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

            var contract = _context.Contracts.Single(c => c.Id == viewModel.Id);

            contract.Name = viewModel.Name;
            contract.Rate = viewModel.Rate;

            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }
    }
}