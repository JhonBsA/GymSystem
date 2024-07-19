using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenterSolution.Web.Controllers
{
    public class RegisterUsers : Controller
    {
        // GET: AccountController
        public IActionResult CreateRegisterUsers()
        {
            return View("~/Views/Customer/CreateRegisterUsers.cshtml"); //cambiar esto
        }


    }
}
