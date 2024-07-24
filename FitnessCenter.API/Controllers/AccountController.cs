﻿using Microsoft.AspNetCore.Cors;
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

        public AccountController(IEmailService emailService)
        {
            _userManager = new UserManager(emailService);
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(UserDetails user)
        {
            var result = _userManager.CreateUsuario(user);
            var msg = result["Message"];
            return Ok(msg);
        }

        [HttpGet]
        [Route("PasswordReset")]
        public IActionResult PasswordReset(string email)
        {
            var result = _userManager.RetrieveByEmail(email);
            var msg = result["Message"];
            return Ok(msg);
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
