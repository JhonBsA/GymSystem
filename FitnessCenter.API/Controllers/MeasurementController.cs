using FitnessCenter.Core;
using FitnessCenter.DTO.MeasurementDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly MeasurementManager _measurementManager;
        public MeasurementController()
        {
            _measurementManager = new MeasurementManager();
        }

        [HttpPost]
        [Route("PostMeasurement")]
        public IActionResult PostMeasurement(Measurement measurement)
        {
            var result = _measurementManager.CreateMeasurement(measurement);
            if (result.ContainsKey("Message"))
            {
                return BadRequest(result["Message"]);
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllMeasurements()
        {
            var result = _measurementManager.GetAllMeasurements();
            if (result == null || result.Count == 0)
            {
                return NotFound("No measurements found");
            }
            return Ok(result);
        }
        [HttpGet("GetByUser")]
        public IActionResult GetMeasurementByUserId([FromQuery] int userId)
        {
            var result = _measurementManager.GetMeasurementByUserId(userId);
            if (result == null || result.Count == 0)
            {
                return NotFound("No measurements found for the specified user.");
            }
            return Ok(result);
        }

    }
}
