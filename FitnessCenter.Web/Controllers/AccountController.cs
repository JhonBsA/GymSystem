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
        public IActionResult Profile()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Verify()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MonthlyPayments()
        {
            return View();
        }

    }
}