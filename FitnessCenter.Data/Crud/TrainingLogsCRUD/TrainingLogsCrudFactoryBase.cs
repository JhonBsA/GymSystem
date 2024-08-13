using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.TrainingLogsDTO;

namespace FitnessCenter.Data.Crud.TrainingLogsCRUD
{
    public abstract class TrainingLogsCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(TrainingLogs entityDTO);
        public abstract List<TrainingLogs> RetrieveAll(int userId);


    }
}
