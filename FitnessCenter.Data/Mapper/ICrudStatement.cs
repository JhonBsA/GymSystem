using FitnessCenter.Data.Dao;
using FitnessCenter.DTO;

namespace FitnessCenter.Data.Mapper
{
    public interface ICrudStatements
    {
        SqlOperation GetCreateStatement(BaseClass entityDTO);
        SqlOperation GetUpdateStatement(BaseClass entityDTO);
        SqlOperation GetDeleteStatement(BaseClass entityDTO);
        SqlOperation GetRetrieveAllStatement();
        SqlOperation GetRetrieveByIdStatement(int Id);
        SqlOperation GetRetrieveByEmailStatement(string email);
        SqlOperation GetPasswordResetOTPStatement(string Otp, string NewPassword);
        SqlOperation Login(string Email, string Password);
    }
}
