using BlueInvoicer.Models;
using System.Linq;
using System.Web.Mvc;

namespace BlueInvoicer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var pendingInvoices = _context.Invoices.Where(i => !i.Paid);
            return View(pendingInvoices);
        }

    }
}