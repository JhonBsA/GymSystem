using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class RoutineController : Controller
    {
        [HttpGet]
        public IActionResult CreateRoutine()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListRoutines()
        {
            return View();
        }
    }
}
