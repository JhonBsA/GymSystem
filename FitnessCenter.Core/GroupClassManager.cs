using FitnessCenter.Data.Crud.GroupClassCRUD;
using FitnessCenter.DTO.GroupClassDTO;

namespace FitnessCenter.Core
{
    public class GroupClassManager
    {

        private readonly GroupClassCrudFactory _groupClassCrudFactory;

        public GroupClassManager()
        {
            _groupClassCrudFactory = new GroupClassCrudFactory();
        }

        public Dictionary<string, string> CreateGroupClass(GroupClass groupClass)
        {
            var result = _groupClassCrudFactory.Create(groupClass);
            return result;
        }

        public List<GroupClass> GetAllGroupClasses()
        {
            var result = _groupClassCrudFactory.RetrieveAll();
            return result;
        }

        public Dictionary<string, string> DeleteGroupClass(int classID)
        {
            var result = _groupClassCrudFactory.Delete(classID);
            return result;
        }

        public Dictionary<string, string> UpdateGroupClass(GroupClass groupClass)
        {
            var result = _groupClassCrudFactory.Update(groupClass);
            return result;
        }
    }
}
