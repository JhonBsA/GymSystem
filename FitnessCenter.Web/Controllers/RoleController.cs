using FitnessCenter.Web.Models.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.Web.Controllers
{
    public class RoleController : Controller
    {
        [HttpGet]
        public IActionResult ListAccess()
        {
            // Simulación de datos para la vista
            var accessList = new List<RoleAccessViewModel>
            {
                new RoleAccessViewModel
                {
                    AccessId = 1,
                    AccessName = "Admin Access",
                    Description = "Access for admins",
                    RolesWithAccess = new List<string> { "Admin", "SuperAdmin" }
                },
                new RoleAccessViewModel
                {
                    AccessId = 2,
                    AccessName = "User Access",
                    Description = "Access for users",
                    RolesWithAccess = new List<string> { "User", "Member" }
                }
            };

            return View(accessList);
        }

        [HttpGet]
        public IActionResult AssignRoleAccess()
        {
            return View();
        }
    }
}
