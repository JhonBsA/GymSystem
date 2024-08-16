using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.GroupClassDTO;
using FitnessCenter.Data.Mapper.GroupClassMapper;

namespace FitnessCenter.Data.Crud.GroupClassCRUD
{
    public class GroupClassCrudFactory
    {
        private static GroupClassMapper mapper;
        private readonly SqlDao dao;

        public GroupClassCrudFactory()
        {
            mapper = new GroupClassMapper();
            dao = SqlDao.GetInstance();
        }

        public Dictionary<string, string> Create(GroupClass entityDTO)
        {
            SqlOperation operation = mapper.GetCreateGroupClassStatement(entityDTO);
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

        public List<GroupClass> RetrieveAll()
        {
            SqlOperation operation = mapper.GetRetrieveAllGroupClassStatement();
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var groupClasses = mapper.BuildObjects(result);
            return groupClasses;
        }

        public Dictionary<string, string> Delete(int classID)
        {
            SqlOperation operation = mapper.GetDeleteGroupClassStatement(classID);
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

        public Dictionary<string, string> Update(GroupClass entityDTO)
        {
            SqlOperation operation = mapper.GetUpdateGroupClassStatement(entityDTO);
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

        public GroupClass RetrieveById(int classID)
        {
            SqlOperation operation = mapper.GetRetrieveGroupClassByIdStatement(classID);
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            if (result.Count == 0)
            {
                throw new Exception("No response from stored procedure.");
            }
            var groupClass = mapper.BuildObject(result[0]);
            return groupClass;
        }

    }
}
