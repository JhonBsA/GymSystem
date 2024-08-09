using FitnessCenter.Core;
using FitnessCenter.DTO.TrainingLogsDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingLogsController : Controller
    {
        private readonly TrainingLogsManager _trainingLogsManager;
        public TrainingLogsController()
        {
            _trainingLogsManager = new TrainingLogsManager();
        }

        [HttpGet("UserTrainingLogs")]

        public IActionResult UserTrainingLogs(int userId)
        {
            var result = _trainingLogsManager.GetTrainingLogsByUserId(userId);
            if (result == null || result.Count == 0)
            {
                return NotFound("No training logs found for this user.");
            }
            return Ok(result);
        }

        [HttpPost("AddTrainingLog")]
        public IActionResult AddTrainingLog(TrainingLogs trainingLog)
        {
            var result = _trainingLogsManager.CreateTrainingLogs(trainingLog);
            if (result.ContainsKey("Message"))
            {
                return BadRequest(result["Message"]);
            }
            return Ok(result);
        }
    }
}
