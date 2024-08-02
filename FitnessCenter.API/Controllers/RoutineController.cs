using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO.RoutineDTO;
using FitnessCenter.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly RoutineManager _routineManager;

        public RoutineController()
        {
            _routineManager = new RoutineManager();
        }

        /*[HttpPost]
        [Route("CreateRoutine")]
        public IActionResult CreateRoutine(Routine routine, List<RoutineExercise> exercises, 
            List<RoutineEquipment> equipment)
        {
            var result = _routineManager.CreateRoutine(routine, exercises, equipment);
            return Ok(result);
        }*/

        [HttpPost]
        [Route("CreateRoutine")]
        public IActionResult CreateRoutine([FromBody] RoutineRequest request)
        {
            var routine = request.Routine;
            var exerciseDetails = request.ExerciseDetails;

            var result = _routineManager.CreateRoutine(routine, exerciseDetails);

            return Ok(result);
        }

        [HttpGet]
        [Route("RetrieveRoutineByClient")]
        public IActionResult RetrieveRoutineByClient(int userId)
        {
            var result = _routineManager.RetrieveByClient(userId);

            if (result == null || result.Count == 0)
            {
                return BadRequest("No routines found for the specified client.");
            }

            return Ok(result);
        }

    }
}

