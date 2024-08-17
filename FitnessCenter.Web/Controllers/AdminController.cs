using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListAppointments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListCustomers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListGroupClasses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
