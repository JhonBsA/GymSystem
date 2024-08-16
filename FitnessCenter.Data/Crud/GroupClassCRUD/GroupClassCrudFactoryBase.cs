using FitnessCenter.Data.Dao;
using FitnessCenter.DTO.GroupClassDTO;

namespace FitnessCenter.Data.Crud.GroupClassCRUD
{
    public abstract class GroupClassCrudFactoryBase
    {
        protected SqlDao dao;

        public abstract Dictionary<string, string> Create(GroupClass entityDTO);
        public abstract List<GroupClass> RetrieveAll();
        public abstract Dictionary<string, string> Delete(int classID);
        public abstract Dictionary<string, string> Update(GroupClass entityDTO);

    }
}
