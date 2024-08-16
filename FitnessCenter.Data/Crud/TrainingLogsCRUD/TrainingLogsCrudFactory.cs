using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.TrainingLogsDTO;
using FitnessCenter.Data.Mapper.TrainingLogsMapper;
using FitnessCenter.DTO.PaymentDTO.FitnessCenter.DTO.PaymentDTO;
using FitnessCenter.Data.Mapper.PaymentMapper;
using Microsoft.Data.SqlClient;

namespace FitnessCenter.Data.Crud.TrainingLogsCRUD
{
    public class TrainingLogsCrudFactory : TrainingLogsCrudFactoryBase
    {
        private TrainingLogsMapper mapper;
        private readonly SqlDao dao;

        public TrainingLogsCrudFactory()
        {
            mapper = new TrainingLogsMapper();
            dao = SqlDao.GetInstance();
        }
        public override Dictionary<string, string> Create(TrainingLogs entityDTO)
        {
            SqlOperation operation = mapper.GetCreateTrainingLogsStatement(entityDTO);
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
        public override List<TrainingLogs> RetrieveAll(int userId)
        {

            SqlOperation operation = mapper.GetRetrieveTrainingLogsByUserIdStatement(userId);
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

            var trainingLogs = mapper.BuildTrainingLogsObjects(result);
            return trainingLogs;

        }
        */

        //prueba
        public override List<TrainingLogs> RetrieveAll(int userId)
        {
            try
            {
                // Obtén la operación SQL para el procedimiento almacenado
                SqlOperation operation = mapper.GetRetrieveTrainingLogsByUserIdStatement(userId);

                // Ejecuta el procedimiento almacenado y obtén el resultado
                var result = dao.ExecuteStoredProcedureWithResult(operation);

                // Verifica si el resultado está vacío
                if (result.Count == 0)
                {
                    // Si no hay datos, puedes devolver una lista vacía
                    // en lugar de lanzar una excepción.
                    Console.WriteLine("No training logs found for the specified user.");
                    return new List<TrainingLogs>();
                }

                // Procesa la primera fila del resultado
                var firstRow = result[0];
                var response = new Dictionary<string, string>();

                // Llena el diccionario con los datos de la primera fila
                foreach (var key in firstRow.Keys)
                {
                    response[key] = firstRow[key].ToString();
                }

                // Mapea el resultado a objetos TrainingLogs
                var trainingLogs = mapper.BuildTrainingLogsObjects(result);
                return trainingLogs;
            }
            catch (SqlException sqlEx)
            {
                // Maneja excepciones específicas de SQL, como problemas con el procedimiento almacenado
                // Puedes registrar el error y lanzar una excepción o devolver una lista vacía según sea necesario
                Console.Error.WriteLine($"SQL Error: {sqlEx.Message}");
                // Dependiendo del contexto, podrías querer devolver una lista vacía aquí también
                return new List<TrainingLogs>();
            }
            catch (Exception ex)
            {
                // Maneja excepciones generales
                Console.Error.WriteLine($"Error: {ex.Message}");
                // Devolvemos una lista vacía en caso de error
                return new List<TrainingLogs>();
            }
        }

    }
}
