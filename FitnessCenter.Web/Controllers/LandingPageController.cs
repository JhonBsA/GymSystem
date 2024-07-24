using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenterSolution.Web.Controllers
{
    public class LandingPageController : Controller
    {
        // GET: AccountController
        public IActionResult LandingPage()
        {
            return View(); 
        }


    }
}
