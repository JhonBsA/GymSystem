using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO;
using FitnessCenter.Core;


namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("CreateUser")]
        public ActionResult CreateUser(UserDetails user)
        {
            UserManager manager = new UserManager();
            manager.CreateUsuario(user);
            return Ok();
        }
        [HttpGet]
        [Route("PasswordResetEmail")]
        [Route("PasswordReset")]
        public ActionResult PasswordReset(string email)
        {
            UserManager manager = new UserManager();
            var result = manager.RetrieveByEmail(email);
            return Ok(result);
        }

        [HttpPost]
        [Route("PasswordResetOTP")]
        public ActionResult PasswordResetOTP(string Otp, string NewPassword)
        {
            UserManager manager = new UserManager();
            var result = manager.PasswordResetOTP(Otp, NewPassword);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string Email, string Password)
        {
            UserManager manager = new UserManager();
            var result = manager.Login(Email, Password);
            return Ok(result);
        }
    }
}
