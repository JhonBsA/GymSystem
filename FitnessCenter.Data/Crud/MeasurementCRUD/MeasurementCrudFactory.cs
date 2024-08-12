using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.MeasurementDTO;
using FitnessCenter.Data.Mapper.MeasurementMapper;


namespace FitnessCenter.Data.Crud.MeasurementCRUD
{
   public class MeasurementCrudFactory : MeasurementCrudFactoryBase
    {
        private MeasurementMapper mapper;
        private readonly SqlDao dao;
        public MeasurementCrudFactory()
        {
            mapper = new MeasurementMapper();
            dao = SqlDao.GetInstance();
        }

        public override Dictionary<string, string> Create(Measurement entityDTO)
        {
            SqlOperation operation = mapper.GetCreateMeasurementStatement(entityDTO);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var firstRow = result[0];
            var response = new Dictionary<string, string>();

            foreach (var key in firstRow.Keys)
            {
                response[key] = firstRow[key].ToString();
            }

            return response;
        }

        public override List<Measurement> RetrieveAll(int userId)
        {
            SqlOperation operation = mapper.GetRetrieveMeasurementByUserIdStatement(userId);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var measurements = mapper.BuildMeasurementObjects(result);
            return measurements;
        }

        public override List<Measurement> RetrieveAll()
        {
            SqlOperation operation = mapper.GetRetrieveAllMeasurementStatement();
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var measurements = mapper.BuildMeasurementObjects(result);
            return measurements;
        }

        public override Dictionary<string, string> Delete(int id)
        {
            SqlOperation operation = mapper.GetDeleteMeasurementStatement(id);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var response = new Dictionary<string, string>();
            foreach (var key in result[0].Keys)
            {
                response[key] = result[0][key].ToString();
            }
            return response;
        }


    }
}
