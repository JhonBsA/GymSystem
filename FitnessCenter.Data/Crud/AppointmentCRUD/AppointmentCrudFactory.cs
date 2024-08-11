using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Mapper.AppointmentMapper;
using FitnessCenter.DTO.AppointmentDTO;
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
       

    }
}
