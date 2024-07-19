using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
        private readonly UserManager _userManager;

        public AccountController()
        {
            _userManager = new UserManager();
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(UserDetails user)
        {
<<<<<<< HEAD
            var result = _userManager.CreateUsuario(user);
            return Ok(result);
        }

        [HttpGet]
        [Route("PasswordReset")]
        public IActionResult PasswordReset(string email)
        {
            var result = _userManager.RetrieveByEmail(email);
=======
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
>>>>>>> JBSA
            return Ok(result);
        }

        [HttpPost]
        [Route("PasswordResetOTP")]
        public IActionResult PasswordResetOTP(string otp, string newPassword)
        {
            var result = _userManager.PasswordResetOTP(otp, newPassword);
            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            var result = _userManager.Login(email, password);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserByUserID")]
        public IActionResult GetUserByUserID(int UserID)
        {
            var result = _userManager.GetUserByUserID(UserID);
            return Ok(result);
        }
    }
}
