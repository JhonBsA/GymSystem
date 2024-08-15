using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.GroupClassDTO;


namespace FitnessCenter.Data.Mapper.GroupClassMapper
{
    public class GroupClassMapper : IGroupClassMapper
    {
        public GroupClass BuildObject(Dictionary<string, object> objectRow)
        {

            if (objectRow == null || objectRow.Count == 0)
            {
                throw new ArgumentException("objectRow is null or empty");
            }
            var groupClass = new GroupClass()
            {
                ClassID = Convert.ToInt32(objectRow["ClassID"]),
                ClassName = objectRow["ClassName"] as string,
                Capacity = Convert.ToInt32(objectRow["Capacity"]),
                Schedule = Convert.ToDateTime(objectRow["Schedule"])

            };
            return groupClass;
        }

        public List<GroupClass> BuildObjects(List<Dictionary<string, object>> objectRows)
        {
            if (objectRows == null || objectRows.Count == 0)
            {
                throw new ArgumentException("objectRows is null or empty");
            }

            var groupClasses = new List<GroupClass>();

            foreach (var objectRow in objectRows)
            {
                {
                    var groupClasse = BuildObject(objectRow);
                    groupClasses.Add(groupClasse);
                }
               
            }
            return groupClasses;
        }

        public SqlOperation GetCreateGroupClassStatement(GroupClass entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "CreateGroupClass"
            };
            operation.AddVarcharParam("ClassName", entityDTO.ClassName);
            operation.AddIntegerParam("Capacity", entityDTO.Capacity);
            operation.AddDateTimeParam("Schedule", entityDTO.Schedule);
            return operation;

        }

        public SqlOperation GetUpdateGroupClassStatement(GroupClass entityDTO)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "UpdateGroupClass"
            };
            operation.AddIntegerParam("ClassID", entityDTO.ClassID);
            operation.AddVarcharParam("ClassName", entityDTO.ClassName);
            operation.AddIntegerParam("Capacity", entityDTO.Capacity);
            operation.AddDateTimeParam("Schedule", entityDTO.Schedule);
            return operation;
        }

        public SqlOperation GetDeleteGroupClassStatement(int classID)
        {
            var operation = new SqlOperation
            {
                ProcedureName = "DeleteGroupClassById"
            };
            operation.AddIntegerParam("ClassID", classID);
            return operation;
        }

        public SqlOperation GetRetrieveAllGroupClassStatement()
        {
            var operation = new SqlOperation
            {
                ProcedureName = "GetAllGroupClass"
            };
            return operation;
        }

        public SqlOperation GetRetrieveGroupClassByClassIDStatement(int classID)
        {
            throw new NotImplementedException();
        }
    }
}
