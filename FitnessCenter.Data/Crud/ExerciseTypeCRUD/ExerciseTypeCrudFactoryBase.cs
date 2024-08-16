using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.ExerciseTypeDTO;

namespace FitnessCenter.Data.Crud.ExerciseTypeCRUD
{
    public abstract class ExerciseTypeCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(ExerciseType entityDTO);
        public abstract Dictionary<string, string> Update(ExerciseType entityDTO);
        public abstract Dictionary<string, string> Delete(ExerciseType entityDTO);
        public abstract List<ExerciseType> RetrieveAll();
    }
}
