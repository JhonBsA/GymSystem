using FitnessCenter.Data.Dao;
using FitnessCenter.DTO;

namespace DataAccess.Mapper
{
    public interface ICrudStatements
    {
        SqlOperation GetCreateStatement(BaseClass entityDTO);
        SqlOperation GetUpdateStatement(BaseClass entityDTO);
        SqlOperation GetDeleteStatement(BaseClass entityDTO);
        SqlOperation GetRetrieveAllStatement();
        SqlOperation GetRetrieveByIdStatement(int Id);
        SqlOperation GetRetrieveByEmailStatement(string email);
<<<<<<< HEAD
        SqlOperation GetPasswordResetOTPStatement(string Otp, string NewPassword);
        SqlOperation Login(string Email, string Password);
=======
>>>>>>> 2032cc1c34dfc49b772443d180f876b624aa8eed
    }
}
