using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO.RoleDTO;
using FitnessCenter.Core;

namespace FitnessCenter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager _roleManager;

        public RoleController()
        {
            _roleManager = new RoleManager();
        }

        [HttpPost]
        [Route("CreateRole")]
        public IActionResult Create(Role role)
        {
            var result = _roleManager.CreateRole(role);
            if (result.ContainsKey("MESSAGE"))
            {
                return BadRequest(result["MESSAGE"]);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("RetrievaAllRoles")]
        public IActionResult RetrieveAll()
        {
            var result = _roleManager.RetrieveAll();
            return Ok(result);
        }

        //Anterior
        //[HttpPut]
        //[Route("UpdateRoleName")]
        //public IActionResult UpdateRoleName([FromBody] UpdateRoleNameRequest request)
        //{
        //    var result = _roleManager.UpdateRoleName(request.OldRoleName, request.NewRoleName);
        //    if (result.ContainsKey("Message"))
        //    {
        //        if (result["Message"].Contains("Error"))
        //        {
        //            return BadRequest(result["Message"]);
        //        }
        //        return Ok(result["Message"]);
        //    }
        //    return Ok(result);
        //}

        [HttpPut]
        [Route("UpdateRoleName")]
        public IActionResult UpdateRoleName([FromBody] UpdateRoleNameRequest request)
        {
            var result = _roleManager.UpdateRoleName(request.OldRoleName, request.NewRoleName);
            var message = result["Message"];

            if (message == "Role not found.")
            {
                return NotFound(new { Message = "Rol no encontrado" });
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("SetUserRole")]
        public IActionResult SetUserRole([FromBody] SetRole request)
        {
            var result = _roleManager.SetUserRole(request.userID, request.roleName);
            return Ok(result);
        }


    }
}

