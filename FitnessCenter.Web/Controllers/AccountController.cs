using FitnessCenter.Web.Models;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO;
using FitnessCenter.Core;

namespace FitnessCenter.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Verify()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(UserDetails user)
        {
            var result = _userManager.CreateUsuario(user);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
