using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Dao
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        public void AddVarcharParam(string parameterName, string paramValue)
        {
            Parameters.Add(new SqlParameter("@" + parameterName, paramValue));
        }

        public void AddIntegerParam(string parameterName, int paramValue)
        {
            Parameters.Add(new SqlParameter("@" + parameterName, paramValue));
        }

        public void AddDateTimeParam(string parameterName, DateTime paramValue)
        {
            Parameters.Add(new SqlParameter("@" + parameterName, paramValue));
        }

        // Método para agregar un parámetro de tipo DateOnly
        public void AddDateOnlyParam(string parameterName, DateOnly paramValue)
        {
            // Convertir DateOnly a DateTime con la hora establecida en medianoche
            DateTime dateTimeValue = paramValue.ToDateTime(TimeOnly.MinValue);
            Parameters.Add(new SqlParameter("@" + parameterName, dateTimeValue));
        }

        // Método para agregar un parámetro de tipo decimal
        public void AddDecimalParam(string parameterName, decimal paramValue)
        {
            Parameters.Add(new SqlParameter("@" + parameterName, paramValue));
        }
        public void AddFloatParam(string parameterName, float paramValue)
        {
            Parameters.Add(new SqlParameter("@" + parameterName, paramValue));
        }
    }
}
