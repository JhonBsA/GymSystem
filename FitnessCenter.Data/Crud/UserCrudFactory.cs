using Azure;
using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Mapper;
using FitnessCenter.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.Data.Crud
{
    public class UserCrudFactory : CrudFactory
    {
        private UsersMapper mapper;

        public UserCrudFactory()
        {
            mapper = new UsersMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseClass users)
        {
            //throw new NotImplementedException();
            SqlOperation operation = mapper.GetCreateStatement(users);
            dao.ExecuteStoredProcedure(operation);
        }

        public override void Delete(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }
        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
        public override BaseClass RetrieveById(int id)
        {
            throw new NotImplementedException();
        }
        public override void Update(BaseClass entityDTO)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> RetrieveByEmail(string email)
        {
            SqlOperation operation = mapper.GetRetrieveByEmailStatement(email);
            var result = dao.ExecuteStoredProcedureWithResult(operation);

            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }

            var firstRow = result[0];
            var response = new Dictionary<string, string>();

            if (firstRow.ContainsKey("Message"))
            {
                response["Message"] = firstRow["Message"].ToString();
            }
            if (firstRow.ContainsKey("OTPCode"))
            {
                response["OTPCode"] = firstRow["OTPCode"].ToString();
            }
            if (firstRow.ContainsKey("OTPState"))
            {
                response["OTPState"] = firstRow["OTPState"].ToString();
            }

            return response;
        }

        public Dictionary<string, string> PasswordResetOTP(string Otp, string NewPassword)
        {
            SqlOperation operation = mapper.GetPasswordResetOTPStatement(Otp, NewPassword);
            var result = dao.ExecuteStoredProcedureWithResult(operation);

            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }

            var firstRow = result[0];
            var response = new Dictionary<string, string>();

            if (firstRow.ContainsKey("Email"))
            {
                response["Email"] = firstRow["Email"].ToString();
            }
            if (firstRow.ContainsKey("StatusCode"))
            {
                response["StatusCode"] = firstRow["StatusCode"].ToString();
            }
            if (firstRow.ContainsKey("Message"))
            {
                response["Message"] = firstRow["Message"].ToString();
            }

            return response;
        }

        public Dictionary<string, string> Login(string Email, string Password)
        {
            SqlOperation operation = mapper.Login(Email, Password);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0) {
                throw new Exception("No response from stored procedure.");
            }
            var firstRow = result[0];
            var response = new Dictionary<string, string>();

            if (firstRow.ContainsKey("Message"))
            {
                response["Message"] = firstRow["Message"].ToString();
            }
            if (firstRow.ContainsKey("RoleID"))
            {
                response["RoleID"] = firstRow["RoleID"].ToString();
            }

            if (firstRow.ContainsKey("UserID"))
            {
                response["UserID"] = firstRow["UserID"].ToString();
            }

            return response;
        }

    }
}
