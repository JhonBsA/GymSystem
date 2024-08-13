using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using FitnessCenter.Core;
using FitnessCenter.DTO.GroupClassDTO;


namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupClassController : ControllerBase
    {
        private readonly GroupClassManager _groupClassManager;

        public GroupClassController()
        {
            _groupClassManager = new GroupClassManager();
        }

        [HttpPost("CreateGroupClass")]
        public IActionResult CreateGroupClass(GroupClass groupClass)
        {
            var result = _groupClassManager.CreateGroupClass(groupClass);
            if (result.ContainsKey("Message"))
            {
                return BadRequest(result["Message"]);
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllGroupClasses()
        {
            var result = _groupClassManager.GetAllGroupClasses();
            if (result == null || result.Count == 0)
            {
                return NotFound("No group classes found");
            }
            return Ok(result);
        }

        [HttpDelete("DeleteGroupClass/{classID}")]
        public IActionResult DeleteGroupClass(int classID)
        {
            var result = _groupClassManager.DeleteGroupClass(classID);
            if (result.ContainsKey("Message"))
            {
                return BadRequest(result["Message"]);
            }
            return Ok(result);
        }

        [HttpPut("UpdateGroupClass")]
        public IActionResult UpdateGroupClass(GroupClass groupClass)
        {
            var result = _groupClassManager.UpdateGroupClass(groupClass);
            if (result.ContainsKey("Message"))
            {
                return BadRequest(result["Message"]);
            }
            return Ok(result);
        }
    }
}
