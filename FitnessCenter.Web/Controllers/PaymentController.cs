using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult CreatePayments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListPayments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PaymentDetails()
        {
            return View();
        }
    }
}
