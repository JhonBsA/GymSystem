using FitnessCenter.Data.Crud.ExerciseTypeCRUD;
using FitnessCenter.DTO.ExerciseDTO;
using FitnessCenter.DTO.ExerciseTypeDTO;

namespace FitnessCenter.Core
{
    public class ExerciseTypeManager
    {
        private readonly ExerciseTypeCrudFactory _exerciseTypeCrud;

        public ExerciseTypeManager()
        {
            _exerciseTypeCrud = new ExerciseTypeCrudFactory();
        }

        public Dictionary<string, string> CreateExerciseType(ExerciseType exerciseType)
        {
            var result = _exerciseTypeCrud.Create(exerciseType);
            return result;
        }

        public Dictionary<string, string> UpdateExerciseType(ExerciseType exerciseType)
        {
            var result = _exerciseTypeCrud.Update(exerciseType);
            return result;
        }

        public Dictionary<string, string> DeleteExerciseType(int exerciseTypeID)
        {
            var result = _exerciseTypeCrud.Delete(exerciseTypeID);
            return result;
        }

        public List<ExerciseType> GetAllExerciseTypes()
        {
            var result = _exerciseTypeCrud.RetrieveAll();
            return result;
        }
    }
}
