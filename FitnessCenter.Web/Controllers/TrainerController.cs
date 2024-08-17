using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class TrainerController : Controller
    {
        [HttpGet]
        public IActionResult ListGroupClasses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateGroupClasses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateGroupClasses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateAppointment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateMeasurement()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateExercise()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateEquipment()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateExerciseType()
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
