using System;

// En FitnessCenter.DTO
namespace FitnessCenter.DTO
{
    public class PasswordResetRequest
    {
        public string Otp { get; set; }
        public string NewPassword { get; set; }
    }
}
