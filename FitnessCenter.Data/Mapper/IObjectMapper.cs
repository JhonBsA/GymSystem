using FitnessCenter.DTO;

namespace FitnessCenter.Data.Mapper
{
    public interface IObjectMapper
    {
        BaseClass BuildObject(Dictionary<string, object> objectRow);
        List<BaseClass> BuildObjects(List<Dictionary<string, object>> objectRows);
    }
}
