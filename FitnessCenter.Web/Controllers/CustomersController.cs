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
       

    }
}