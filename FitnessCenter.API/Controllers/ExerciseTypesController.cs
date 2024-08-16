using Microsoft.AspNetCore.Cors;
using FitnessCenter.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessCenter.DTO.ExerciseTypeDTO;

namespace FitnessCenter.API.Controllers
{
    [EnableCors("NocheCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseTypesController : ControllerBase
    {
        private readonly ExerciseTypeManager _exerciseTypeManager;

        public ExerciseTypesController()
        {
            _exerciseTypeManager = new ExerciseTypeManager();
        }

        [HttpPost]
        [Route("CreateExerciseType")]
        public IActionResult CreateExerciseType(ExerciseType exerciseType)
        {
            var result = _exerciseTypeManager.CreateExerciseType(exerciseType);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateExerciseType")]
        public IActionResult UpdateExerciseType(ExerciseType exerciseType)
        {
            var result = _exerciseTypeManager.UpdateExerciseType(exerciseType);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteExerciseType")]
        public IActionResult DeleteExerciseType(int exerciseTypeID)
        {
            var result = _exerciseTypeManager.DeleteExerciseType(exerciseTypeID);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllExerciseTypes")]
        public IActionResult GetAllExerciseTypes()
        {
            var result = _exerciseTypeManager.GetAllExerciseTypes();
            return Ok(result);
        }
    }
}
