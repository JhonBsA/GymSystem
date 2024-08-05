using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.PaymentDTO;

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
            throw new NotImplementedException();
        }

        public List<UserPaymentMethod> BuildUserPaymentMethodObjects(List<Dictionary<string, object>> objectRows)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetCreatePaymentStatement(Payment entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetCreatePayment"
            };

            //operation.AddIntegerParam("PaymentID", entityDTO.PaymentID);
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
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllUserPaymentMethodsStatement()
        {
            throw new NotImplementedException();
        }
    }
}
