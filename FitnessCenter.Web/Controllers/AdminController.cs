﻿using FitnessCenter.Web.Models;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO;
using FitnessCenter.Core;

namespace FitnessCenter.Web.Controllers
{
    public class AdminController : Controller
    {



        [HttpGet]
        public IActionResult home()
        {
            return View();
        }

       /* [HttpPost]
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
        }*/
    }
}
