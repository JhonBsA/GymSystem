using Azure;
using FitnessCenter.Data.Dao;
using FitnessCenter.DTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper
{
    public class UsersMapper : IObjectMapper, ICrudStatements
    {
        public List<BaseClass> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            var usersList = new List<BaseClass>();
            foreach (var row in objectRows)
            {
                usersList.Add(BuildObject(row));
            }
            return usersList;
        }

        public BaseClass BuildObject(Dictionary<string, object> objectRow)
        {
            return new UserDetails()
            {
                UserID = objectRow.ContainsKey("UserID") ? Convert.ToInt32(objectRow["UserID"]) : 0,
                Cedula = objectRow.ContainsKey("Cedula") ? Convert.ToInt32(objectRow["Cedula"]) : 0,
                Nombre = objectRow.ContainsKey("Nombre") ? objectRow["Nombre"].ToString() : string.Empty,
                FirstLastName = objectRow.ContainsKey("FirstLastName") ? objectRow["FirstLastName"].ToString() : string.Empty,
                SecondLastName = objectRow.ContainsKey("SecondLastName") ? objectRow["SecondLastName"].ToString() : string.Empty,
                Phone = objectRow.ContainsKey("Phone") ? objectRow["Phone"].ToString() : string.Empty,
                Email = objectRow.ContainsKey("Email") ? objectRow["Email"].ToString() : string.Empty,
                RoleName = objectRow.ContainsKey("RoleName") ? objectRow["RoleName"].ToString() : string.Empty
            };
        }

        public SqlOperation GetCreateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "CreateUser"
            };

            UserDetails user = (UserDetails)entityDTO;

            operation.AddIntegerParam("CedulaP", user.Cedula); 
            operation.AddVarcharParam("NombreP", user.Nombre);
            operation.AddVarcharParam("FirstLastNameP", user.FirstLastName);
            operation.AddVarcharParam("SecondLastNameP", user.SecondLastName);
            operation.AddVarcharParam("PhoneP", user.Phone);
            operation.AddVarcharParam("EmailP", user.Email);
            operation.AddVarcharParam("RoleNameP", user.RoleName);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "UpdateUser"
            };

            UserDetails user = (UserDetails)entityDTO;

            operation.AddIntegerParam("UserID", user.UserID ?? 0);
            operation.AddIntegerParam("CedulaP", user.Cedula);
            operation.AddVarcharParam("NombreP", user.Nombre);
            operation.AddVarcharParam("FirstLastNameP", user.FirstLastName);
            operation.AddVarcharParam("SecondLastNameP", user.SecondLastName);
            operation.AddVarcharParam("PhoneP", user.Phone);
            operation.AddVarcharParam("EmailP", user.Email);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "DeleteUser"
            };

            UserDetails user = (UserDetails)entityDTO;

            operation.AddIntegerParam("CedulaP", user.Cedula);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByIdStatement(int ID)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "GetUserByUserID"
            };

            operation.AddIntegerParam("UserID", ID);
            return operation;
        }


        public SqlOperation GetRetrieveByEmailStatement(string email)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "GetUser"
            };
            operation.AddVarcharParam("EmailP",email);
            return operation;
        }

        public SqlOperation GetPasswordResetOTPStatement(string Otp, string NewPassword)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "VerifyAndResetOTP"
            };
            operation.AddVarcharParam("OTPP", Otp);
            operation.AddVarcharParam("NewPassword", NewPassword);
            return operation;
        }

        public SqlOperation Login(string Email, string Password)
        {
            SqlOperation operation = new SqlOperation
            {
                ProcedureName = "GetLogin"
            };
            operation.AddVarcharParam("EmailP", Email);
            operation.AddVarcharParam("PasswordP", Password);
            return operation;
        }
    }
}
