using FitnessCenter.DTO.MeasurementDTO;
using FitnessCenter.Data.Crud.MeasurementCRUD;
using System.Collections.Generic;

namespace FitnessCenter.Core
{
    public class MeasurementManager
    {
        private readonly MeasurementCrudFactory _measurementCrudFactory;

        public MeasurementManager()
        {
            _measurementCrudFactory = new MeasurementCrudFactory();
        }

        public Dictionary<string, string> CreateMeasurement(Measurement measurement)
        {
            var result = _measurementCrudFactory.Create(measurement);
            return result;
        }

        public List<Measurement> GetMeasurementByUserId(int userId)
        {
            var result = _measurementCrudFactory.RetrieveAll(userId);
            return result;
        }

        public List<Measurement> GetAllMeasurements()
        {
            var result = _measurementCrudFactory.RetrieveAll();
            return result;
        }

        public Dictionary<string, string> DeleteMeasurement(int id)
        {
            var result = _measurementCrudFactory.Delete(id);
            return result;
        }


    }
}
