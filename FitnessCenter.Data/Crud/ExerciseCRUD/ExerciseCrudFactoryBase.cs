using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.ExerciseDTO;


namespace FitnessCenter.Data.Crud.ExerciseCRUD
{
    public abstract class ExerciseCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(Exercise entityDTO);
        public abstract Dictionary<string, string> Update(Exercise entityDTO);
        public abstract Dictionary<string, string> Delete(int exerciseID);
        public abstract List<Exercise> RetrieveAll();
    }
}
