using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.PaymentDTO;
using FitnessCenter.DTO.PaymentDTO.FitnessCenter.DTO.PaymentDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.PaymentMapper
{
    public class PaymentMapper : IPaymentMapper
    {
        public Payment BuildPaymentObject(Dictionary<string, object> objectRow)
        {
            throw new NotImplementedException();
        }

        public List<Payment> BuildPaymentObjects(List<Dictionary<string, object>> objectRows)
        {
            throw new NotImplementedException();
        }

        public UserPaymentMethod BuildUserPaymentMethodObject(Dictionary<string, object> objectRow)
        {
            return new UserPaymentMethod
            {
                PaymentMethodID = Convert.ToInt32(objectRow["PaymentMethodID"]),
                UserID = Convert.ToInt32(objectRow["UserID"]),
                PaymentMethodType = objectRow["PaymentMethodType"].ToString(),
                DisplayPaymentMethod = objectRow["DisplayPaymentMethod"].ToString(), // Ensure this is mapped
                CreditCardNumber = null, // Do not include the full credit card number
                CreditCardExpiryDate = objectRow["CreditCardExpiryDate"] != DBNull.Value
                    ? (DateTime?)Convert.ToDateTime(objectRow["CreditCardExpiryDate"])
                    : null,
                PayPalEmail = objectRow["PayPalEmail"] != DBNull.Value ? objectRow["PayPalEmail"].ToString() : null
            };
        }

        public UserPaymentMethodResponse BuildUserPaymentMethodResponseObject(Dictionary<string, object> objectRow)
        {
            return new UserPaymentMethodResponse
            {
                PaymentMethodType = objectRow["PaymentMethodType"].ToString(),
                DisplayPaymentMethod = objectRow["DisplayPaymentMethod"].ToString(),
                PayPalEmail = objectRow["PayPalEmail"] != DBNull.Value ? objectRow["PayPalEmail"].ToString() : null
            };
        }

        public List<UserPaymentMethodResponse> BuildUserPaymentMethodResponseObjects(List<Dictionary<string, object>> objectRows)
        {
            var paymentMethods = new List<UserPaymentMethodResponse>();

            foreach (var row in objectRows)
            {
                paymentMethods.Add(BuildUserPaymentMethodResponseObject(row));
            }

            return paymentMethods;
        }

        public SqlOperation GetCreatePaymentStatement(Payment entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetCreatePayment"
            };

            operation.AddIntegerParam("ClientID", entityDTO.UserID);
            operation.AddIntegerParam("PaymentMethodID", entityDTO.PaymentMethodID);
            operation.AddDecimalParam("Amount", entityDTO.Amount);
            operation.AddDateTimeParam("PaymentDate", entityDTO.PaymentDate);

            return operation;
        }

        public SqlOperation GetUpdatePaymentStatement(Payment entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeletePaymentStatement(int paymentID)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllPaymentsStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreateUserPaymentMethodStatement(UserPaymentMethod entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetCreateUserPaymentMethod"
            };

            operation.AddIntegerParam("UserID", entityDTO.UserID);
            operation.AddVarcharParam("PaymentMethodType", entityDTO.PaymentMethodType);
            operation.AddVarcharParam("CreditCardNumber", string.IsNullOrEmpty(entityDTO.CreditCardNumber) ? null : entityDTO.CreditCardNumber);
            operation.AddDateTimeParam("CreditCardExpiryDate", entityDTO.CreditCardExpiryDate ?? DateTime.MinValue);
            operation.AddVarcharParam("PayPalEmail", string.IsNullOrEmpty(entityDTO.PayPalEmail) ? null : entityDTO.PayPalEmail);

            return operation;
        }

        public SqlOperation GetUpdateUserPaymentMethodStatement(UserPaymentMethod entityDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteUserPaymentMethodStatement(int paymentMethodID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetDeleteUserPaymentMethod"
            };

            operation.AddIntegerParam("PaymentMethodID", paymentMethodID);

            return operation;
        }

        public SqlOperation GetRetrieveAllUserPaymentMethodsStatement(int UserId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetRetrieveAllUserPaymentMethods"
            };

            operation.AddIntegerParam("UserID", UserId);

            return operation;
        }

        List<UserPaymentMethod> IPaymentMapper.BuildUserPaymentMethodObjects(List<Dictionary<string, object>> objectRows)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetPaymentMethodStatement(string displayPaymentMethod, int UserId)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetPaymentMethod"
            };

            operation.AddVarcharParam("displayPaymentMethod", displayPaymentMethod);
            operation.AddIntegerParam("UserID", UserId);
            return operation;

        }
    }
}
