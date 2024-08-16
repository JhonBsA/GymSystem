using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.MeasurementDTO;
using FitnessCenter.Data.Mapper.MeasurementMapper;
using Microsoft.Data.SqlClient;


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

        /*original
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
        */
        //prueba
        public override List<Measurement> RetrieveAll(int userId)
        {
            try
            {
                // Obtén la operación SQL para el procedimiento almacenado
                SqlOperation operation = mapper.GetRetrieveMeasurementByUserIdStatement(userId);

                // Ejecuta el procedimiento almacenado y obtén el resultado
                var result = dao.ExecuteStoredProcedureWithResult(operation);

                // Verifica si el resultado está vacío
                if (result.Count == 0)
                {
                    // Si no hay datos, puedes devolver una lista vacía
                    // en lugar de lanzar una excepción.
                    Console.WriteLine("No measurements found for the specified user.");
                    return new List<Measurement>();
                }

                // Mapea el resultado a objetos Measurement
                var measurements = mapper.BuildMeasurementObjects(result);
                return measurements;
            }
            catch (SqlException sqlEx)
            {
                // Maneja excepciones específicas de SQL, como problemas con el procedimiento almacenado
                Console.Error.WriteLine($"SQL Error: {sqlEx.Message}");
                // Dependiendo del contexto, podrías querer devolver una lista vacía aquí también
                return new List<Measurement>();
            }
            catch (Exception ex)
            {
                // Maneja excepciones generales
                Console.Error.WriteLine($"Error: {ex.Message}");
                // Devolvemos una lista vacía en caso de error
                return new List<Measurement>();
            }
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
