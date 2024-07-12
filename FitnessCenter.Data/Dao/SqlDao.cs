using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data;

namespace FitnessCenter.Data.Dao
{
    public class SqlDao
    {
        private static SqlDao instance = new SqlDao();

        private string _server = "localhost";
        private string _database = "BioSport";
        private string _userId = "sa";
        private string _password = "Jennifer1!";
        private string _trustServerCertificate = "True";

        private string _connString => $"Server={_server};Database={_database};User ID={_userId};Password={_password};TrustServerCertificate={_trustServerCertificate}";

        public static SqlDao GetInstance()
        {
            if (instance == null)
                instance = new SqlDao();
            return instance;
        }

        public void ExecuteStoredProcedure(SqlOperation operation)
        {
            //hacer la conexion
            string connectionString = _connString;
            SqlConnection conn = new SqlConnection(connectionString);

            //Armar el query
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            //Agregar los parametros
            foreach (var p in operation.Parameters)
            {
                command.Parameters.Add(p);
            }
            //abrir conexion
            conn.Open();
            //Ejecutar el comando
            command.ExecuteNonQuery();
        }


    }
}
