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
                Cedula = Convert.ToInt32(objectRow["cedula"]),
                Nombre = objectRow["nombre"].ToString(),
                FirstLastName = objectRow["primer_apellido"].ToString(),
                SecondLastName = objectRow["segundo_apellido"].ToString(),
                Phone = objectRow["telefono"].ToString(),
                Email = objectRow["email"].ToString(),
                RoleName = objectRow["role_name"].ToString(),
              
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
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByIdStatement(int Id)
        {
            throw new NotImplementedException();
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
