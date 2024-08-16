using FitnessCenter.Core;
using FitnessCenter.DTO.ExerciseDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {

        private readonly ExerciseManager _exerciseManager;

        public ExerciseController()
        {
            _exerciseManager = new ExerciseManager();
        }

        [HttpPost]
        [Route("CreateExercise")]
        public IActionResult CreateExercise(Exercise exercise)
        {
            var result = _exerciseManager.CreateExercise(exercise);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateExercise")]
        public IActionResult UpdateExercise(Exercise exercise)
        {
            var result = _exerciseManager.UpdateExercise(exercise);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteExercise")]
        public IActionResult DeleteExercise(int exerciseID)
        {
            var result = _exerciseManager.DeleteExercise(exerciseID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllExercises")]
        public IActionResult GetAllExercises()
        {
            var result = _exerciseManager.GetAllExercises();
            return Ok(result);
        }
    }
}
