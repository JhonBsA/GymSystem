using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Mapper.AppointmentMapper;
using FitnessCenter.DTO.AppointmentDTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Crud.AppointmentCRUD
{
    public class AppointmentCrudFactory : AppointmentCrudFactoryBase
    {
        private readonly AppointmentMapper mapper;

        public AppointmentCrudFactory()
        {
            mapper = new AppointmentMapper();
            dao = SqlDao.GetInstance();
        }

        public override Dictionary<string, string> Create(AppointmentBaseClass appointment)
        {
            SqlOperation operation = mapper.GetCreateStatement(appointment);
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

        public override Dictionary<string, string> Delete(int appointmentID)
        {
            SqlOperation operation = mapper.GetDeleteStatement(appointmentID);
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

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override AppointmentBaseClass RetrieveById(int id)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> Update(AppointmentBaseClass appointment)
        {
            SqlOperation operation = mapper.GetUpdateStatement(appointment);
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

        public List<Appointment> RetrieveByDateRange(DateTime startDate, DateTime endDate)
        {
            SqlOperation operation = mapper.GetRetrieveByDateRangeStatement(startDate, endDate);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            return mapper.BuildObjects(result);
        }

        public DateTime RetrieveLastAppointmentDate()
        {
            SqlOperation operation = mapper.GetRetrieveLastAppointmentDateStatement();
            var result = dao.ExecuteStoredProcedureWithResult(operation);

            if (result.Count > 0)
            {
                var row = result[0];
                return Convert.ToDateTime(row["LastAppointmentDate"]);
            }

            return DateTime.MinValue; // O cualquier valor por defecto
        }

        /*original
        public AppointmentBaseClass GetAppointmentById(int appointmentID)
        {
            SqlOperation operation = mapper.GetAppointmentById(appointmentID);
            var result = dao.ExecuteStoredProcedureWithResult(operation);

            if (result.Count == 0)
            {
                throw new Exception("No response form stored procedure");
            }

            var firstRow = result[0];
            var appointment = mapper.BuildObject(firstRow);

            return appointment;

        }
        */
        //prueba
        public AppointmentBaseClass GetAppointmentById(int appointmentID)
        {
            try
            {
                // Obtén la operación SQL para el procedimiento almacenado
                SqlOperation operation = mapper.GetAppointmentById(appointmentID);

                // Ejecuta el procedimiento almacenado y obtén el resultado
                var result = dao.ExecuteStoredProcedureWithResult(operation);

                // Verifica si el resultado está vacío
                if (result.Count == 0)
                {
                    // Si no hay datos, puedes devolver null o una instancia predeterminada en lugar de lanzar una excepción.
                    // Aquí devolvemos null para indicar que no se encontró la cita.
                    Console.WriteLine("No appointment found for the specified ID.");
                    return null;
                }

                // Mapea el primer registro del resultado a un objeto AppointmentBaseClass
                var firstRow = result[0];
                var appointment = mapper.BuildObject(firstRow);

                return appointment;
            }
            catch (SqlException sqlEx)
            {
                // Maneja excepciones específicas de SQL, como problemas con el procedimiento almacenado
                Console.Error.WriteLine($"SQL Error: {sqlEx.Message}");
                // Dependiendo del contexto, podrías querer devolver null aquí también
                return null;
            }
            catch (Exception ex)
            {
                // Maneja excepciones generales
                Console.Error.WriteLine($"Error: {ex.Message}");
                // Devolvemos null en caso de error
                return null;
            }
        }
        /*
        public AppointmentBaseClass GetAppointmentsByUserId(int userID)
        {
            SqlOperation operation = mapper.GetAppointmentsByUserId(userID);
            var result = dao.ExecuteStoredProcedureWithResult(operation);

            if (result.Count == 0)
            {
                throw new Exception("No appointments found for the given user ID");
            }
            var firstRow = result[0];
            var appointment = mapper.BuildObject(firstRow);

            return appointment;

        }
        */
        public List<Appointment> GetAppointmentsByUserId(int userID)
        {
            try
            {
                SqlOperation operation = mapper.GetAppointmentsByUserId(userID);
                var result = dao.ExecuteStoredProcedureWithResult(operation);
                return mapper.BuildObjects(result);
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error: {sqlEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

    }

}

