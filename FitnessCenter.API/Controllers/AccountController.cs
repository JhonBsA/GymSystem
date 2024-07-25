using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO;
using FitnessCenter.Core;
using FitnessCenter.Web.Models;

namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager _userManager;

        public AccountController()
        {
            _userManager = new UserManager();
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(UserDetails user)
        {
            var result = _userManager.CreateUsuario(user);
            return Ok(result);
        }

        [HttpGet]
        [Route("PasswordReset")]
        public IActionResult PasswordReset(string email)
        {
            var result = _userManager.RetrieveByEmail(email);
            return Ok(result);
        }

        [HttpPost]
        [Route("PasswordResetOTP")]
        public IActionResult PasswordResetOTP(string otp, string newPassword)
        {
            var result = _userManager.PasswordResetOTP(otp, newPassword);
            return Ok(result);
        }
        //swagger funcional
        //[HttpPost]
        //[Route("Login")]
        //public IActionResult Login(string email, string password)
        //{
        //    var result = _userManager.Login(email, password);
        //    return Ok(result);
        //}

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            var result = _userManager.Login(model.Email, model.Password);

            if (result.ContainsKey("Message"))
            {
                // Devuelve un BadRequest si el resultado contiene un mensaje de error
                return BadRequest(result["Message"]);
            }

            // Devuelve OK si el resultado contiene datos de éxito
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserByUserID")]
        public IActionResult GetUserByUserID(int UserID)
        {
            var result = _userManager.GetUserByUserID(UserID);
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(UserDetails user)
        {
            var result = _userManager.UpdateUser(user);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(UserDetails user)
        {
            var result = _userManager.DeleteUser(user);
            return Ok(result);
        }
    }
}
