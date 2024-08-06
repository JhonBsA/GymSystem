using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.PaymentDTO;
using FitnessCenter.Data.Mapper.PaymentMapper;
using FitnessCenter.DTO.PaymentDTO.FitnessCenter.DTO.PaymentDTO;

namespace FitnessCenter.Data.Crud.PayementCRUD
{
    public class PaymentCrudFactory : PaymentCrudFactoryBase
    {
        private PaymentMapper mapper;
        private readonly SqlDao dao;
        public PaymentCrudFactory()
        {
            mapper = new PaymentMapper();
            dao = SqlDao.GetInstance();
        }

        public override Dictionary<string, string> Create(Payment entityDTO)
        {
            SqlOperation operation = mapper.GetCreatePaymentStatement(entityDTO);
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

        public override List<Payment> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public override Payment RetrieveById(int id)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> Update(Payment entityDTO)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> Delete(int id)
        {
            SqlOperation operation = mapper.GetDeleteUserPaymentMethodStatement(id);
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

        public Dictionary<string, string> AddUserPaymentMethod(UserPaymentMethod entityDTO)
        {
            SqlOperation operation = mapper.GetCreateUserPaymentMethodStatement(entityDTO);
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

        public List<UserPaymentMethodResponse> GetAllUserPaymentMethod(int userId)
        {
            SqlOperation operation = mapper.GetRetrieveAllUserPaymentMethodsStatement(userId);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var paymentMethods = mapper.BuildUserPaymentMethodResponseObjects(result);
            return paymentMethods;
        }
    
    }
}
