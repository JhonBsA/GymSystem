using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.MeasurementDTO;
using FitnessCenter.DTO.PaymentDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.MeasurementMapper
{
    public class MeasurementMapper : IMeasurementMapper
    {

        public Measurement BuildMeasurementObject(Dictionary<string, object> objectRow)
        {
            if (objectRow == null || objectRow.Count == 0)
            {
                throw new ArgumentException("objectRow is null or empty");
            }

            var measurement = new Measurement
            {
                MeasurementID = Convert.ToInt32(objectRow["MeasurementID"]),
                Email = objectRow["Email"] as string,
                TrainerID = Convert.ToInt32(objectRow["TrainerID"]),
                Weight = Convert.ToDecimal(objectRow["Weight"]),
                Height = Convert.ToDecimal(objectRow["Height"]),
                BodyFatPercentage = Convert.ToDecimal(objectRow["BodyFatPercentage"]),
                Age = Convert.ToInt32(objectRow["Age"]),
                Gender = objectRow["Gender"] as string,
                MeasuredAt = Convert.ToDateTime(objectRow["MeasuredAt"])
            };

            return measurement;
        }

        public List<Measurement> BuildMeasurementObjects(List<Dictionary<string, object>> objectRows)
        {
            if (objectRows == null || objectRows.Count == 0)
            {
                throw new ArgumentException("objectRows is null or empty");
            }

            var measurements = new List<Measurement>();

            foreach (var row in objectRows)
            {
                var measurement = BuildMeasurementObject(row);
                measurements.Add(measurement);
            }

            return measurements;
        }

        public Measurement MapToDTO(Dictionary<string, string> row)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> MapToRow(Measurement entityDTO)
        {
            throw new NotImplementedException();
        }

        public Measurement MapToMeasurement(Measurement entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateMeasurementStatement(Measurement entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetCreateMeasurement"
            };

            operation.AddDateTimeParam("MeasuredAt", entityDTO.MeasuredAt);
            operation.AddVarcharParam("Email", entityDTO.Email);
            operation.AddIntegerParam("TrainerID", entityDTO.TrainerID);
            operation.AddDecimalParam("Weight", entityDTO.Weight);
            operation.AddDecimalParam("Height", entityDTO.Height);
            operation.AddDecimalParam("BodyFatPercentage", entityDTO.BodyFatPercentage);
            operation.AddIntegerParam("Age", entityDTO.Age);
            operation.AddVarcharParam("Gender", entityDTO.Gender);

            return operation;
        }

        public SqlOperation GetUpdateMeasurementStatement(Measurement entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteMeasurementStatement(int measurementID)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllMeasurementStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetRetrieveAllMeasurement"
            };

            return operation;
        }

        public SqlOperation GetRetrieveMeasurementByUserIdStatement(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
