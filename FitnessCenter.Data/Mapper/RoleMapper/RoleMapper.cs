using Azure;
using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.RoleDTO;
using System;
using System.Collections.Generic;

namespace FitnessCenter.Data.Mapper.RoleMapper
{
    public class RoleMapper : IRoleMapper
    {
        public Role BuildObject(Dictionary<string, object> objectRow)
        {
            var role = new Role
            {
                RoleID = Convert.ToInt32(objectRow["RoleID"]),
                Name = objectRow["RoleName"].ToString()
            };
            return role;
        }

        public List<Role> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            var roles = new List<Role>();
            foreach (var row in objectRows)
            {
                roles.Add(BuildObject(row));
            }
            return roles;
        }

        public SqlOperation GetCreateStatement(Role role)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "CreateRole"
            };

            operation.AddVarcharParam("Name", role.Name);

            return operation;
        }

        public SqlOperation GetUpdateRoleNameStatement(string oldRoleName, string newRoleName)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateRoleName"
            };

            operation.AddVarcharParam("OldRoleName", oldRoleName);
            operation.AddVarcharParam("NewRoleName", newRoleName);

            return operation;
        }
        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "RetrieveRoles"
            };
            return operation;
        }

        public SqlOperation GetSetUserRoleStatement(int userID, string roleName)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "SetUserRole"
            };

            operation.AddIntegerParam("UserID", userID);
            operation.AddVarcharParam("RoleName", roleName);

            return operation;
        }

    }
}
