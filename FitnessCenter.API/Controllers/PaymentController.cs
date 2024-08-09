using FitnessCenter.Core;
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

        [HttpGet("GetPaymentByUserId")]
        public IActionResult GetPaymentByUserId(int UserId)
        {
            var result = _paymentManager.GetPaymentByUserId(UserId);
            if (result == null || result.Count == 0)
            {
                return NotFound("No payment methods found for this user.");
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

        [HttpDelete]
        [Route("DeleteUserPaymentMethod")]
        public IActionResult DeleteUserPaymentMethod(int id)
        {
            var result = _paymentManager.DeleteUserPaymentMethod(id);
            if (result.ContainsKey("Message"))
            {
                return BadRequest(result["Message"]);
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserPaymentMethods")]
        public IActionResult GetUserPaymentMethods(int userId)
        {
            var paymentMethods = _paymentManager.GetAllUserPaymentMethods(userId);

            if (paymentMethods == null || paymentMethods.Count == 0)
            {
                return NotFound("No payment methods found for this user.");
            }

            return Ok(paymentMethods);
        }

        [HttpGet("GetPaymentMethod")]
        public IActionResult GetPaymentMethod(string displayPaymentMethod, int UserId)
        {
            var result = _paymentManager.GetPaymentMethod(displayPaymentMethod, UserId);
            if (result.ContainsKey("Message"))
            {
                return BadRequest(result["Message"]);
            }
            return Ok(result);
        }
    
    }
    
}
