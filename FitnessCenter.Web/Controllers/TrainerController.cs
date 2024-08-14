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

    }
}
