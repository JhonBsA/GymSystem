using FitnessCenter.Data.Crud.ExerciseCRUD;
using FitnessCenter.DTO.ExerciseDTO;

namespace FitnessCenter.Core
{
    public class ExerciseManager
    {
        private readonly ExerciseCrudFactory _exerciseCrud;

        public ExerciseManager()
        {
            _exerciseCrud = new ExerciseCrudFactory();
        }

        public Dictionary<string, string> CreateExercise(Exercise exercise)
        {
            var result = _exerciseCrud.Create(exercise);
            return result;
        }

        public Dictionary<string, string> UpdateExercise(Exercise exercise)
        {
            var result = _exerciseCrud.Update(exercise);
            return result;
        }

        public Dictionary<string, string> DeleteExercise(int exerciseID)
        {
            var result = _exerciseCrud.Delete(exerciseID);
            return result;
        }

        public List<Exercise> GetAllExercises()
        {
            var result = _exerciseCrud.RetrieveAll();
            return result;
        }
    }
}
