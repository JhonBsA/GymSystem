using FitnessCenter.Data.Dao;
using FitnessCenter.Data.Mapper.RoleMapper;
using FitnessCenter.DTO.RoleDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Crud.RoleCRUD
{
    public class RoleCrudFactory : RoleCrudFactoryBase
    {
        private readonly RoleMapper mapper;
        private readonly SqlDao dao;

        public RoleCrudFactory()
        {
            mapper = new RoleMapper();
            dao = SqlDao.GetInstance();
        }

        public override Dictionary<string, string> Create(Role role)
        {
            SqlOperation operation = mapper.GetCreateStatement(role);
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

        public override Role RetrieveById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Role> RetrieveAll()
        {
            SqlOperation operation = mapper.GetRetrieveAllStatement();
            var result = dao.ExecuteStoredProcedureWithResult(operation);
            var roles = new List<Role>();

            foreach (var row in result)
            {
                roles.Add(mapper.BuildObject(row));
            }

            return roles;
        }

        // Optional method to update role names
        public Dictionary<string, string> UpdateRoleName(string oldRoleName, string newRoleName)
        {
            SqlOperation operation = mapper.GetUpdateRoleNameStatement(oldRoleName, newRoleName);
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
    }
}
