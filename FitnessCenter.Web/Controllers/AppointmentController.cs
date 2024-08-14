using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class AppointmentController : Controller
    {

        [HttpGet]
        public IActionResult ListAppointments()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAppointment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateAppointment()
        {
            return View();
        }
    }
}
