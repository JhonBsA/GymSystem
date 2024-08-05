﻿using FitnessCenter.Core;
using FitnessCenter.DTO.PaymentDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentManager _paymentManager;
        public PaymentController()
        {
            _paymentManager = new PaymentManager();
        }

        [HttpPost]
        [Route("PostPayment")]
        public IActionResult PostPayment(Payment payment)
        {
            var result = _paymentManager.CreatePayment(payment);
            if (result.ContainsKey("MESSAGE"))
            {
                return BadRequest(result["MESSAGE"]);
            }
            if (result.ContainsKey("Message"))
            {
                return BadRequest(result["Message"]);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("AddUserPaymentMethod")]
        public IActionResult AddUserPaymentMethod(UserPaymentMethod paymentMethod)
        {
            var result = _paymentManager.AddUserPaymentMethod(paymentMethod);
            if (result.ContainsKey("MESSAGE"))
            {
                return BadRequest(result["MESSAGE"]);
            }
            return Ok(result);
        }
    }
}
