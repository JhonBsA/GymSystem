using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.MeasurementDTO;

namespace FitnessCenter.Data.Crud.MeasurementCRUD
{
    public abstract class MeasurementCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(Measurement entityDTO);
        public abstract List<Measurement> RetrieveAll(int userId);
        public abstract List<Measurement> RetrieveAll();
        public abstract Dictionary<string, string> Delete(int id);

    }
}
