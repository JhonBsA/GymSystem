using FitnessCenter.Web.Models;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO;
using FitnessCenter.Core;

namespace FitnessCenter.Web.Controllers
{
    public class CustomersController : Controller
    {

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Classes()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Appointments()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Progress()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Trainings()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListCustomers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateCustomers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpdateCustomers()
        {
            return View();
        }

    }
}