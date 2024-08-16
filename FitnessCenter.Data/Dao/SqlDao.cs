using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data;

namespace FitnessCenter.Data.Dao
{
    public class SqlDao
    {
        private static SqlDao instance = new SqlDao();

        private string _server = "localhost"; // Usa doble barra invertida
        private string _database = "BioSport";
        private string _userId = "sa";
        private string _password = "Makober33*";
        private string _trustServerCertificate = "True";

        private string _connString => $"Server={_server};Database={_database};User ID={_userId};Password={_password};TrustServerCertificate={_trustServerCertificate};";

        public static SqlDao GetInstance()
        {
            if (instance == null)
                instance = new SqlDao();
            return instance;
        }

        public List<Dictionary<string, object>> ExecuteStoredProcedure(SqlOperation operation)
        {
            // Hacer la conexión
            string connectionString = _connString;
            SqlConnection conn = new SqlConnection(connectionString);

            // Armar el query
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros
            foreach (var p in operation.Parameters)
            {
                command.Parameters.Add(p);
            }

            // Abrir conexión
            conn.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                var result = new List<Dictionary<string, object>>();
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }
                    result.Add(row);
                }
                return result;
            }
        }

        public List<Dictionary<string, object>> ExecuteStoredProcedureWithResult(SqlOperation operation)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = operation.ProcedureName;
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var p in operation.Parameters)
                    {
                        command.Parameters.Add(p);
                    }

                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var result = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[reader.GetName(i)] = reader.GetValue(i);
                            }
                            result.Add(row);
                        }
                        return result;
                    }
                }
            }
        }
    }
}
