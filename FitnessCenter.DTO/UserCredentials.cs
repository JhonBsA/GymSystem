using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter.DTO
{
    public class UserCredentials
    {
        public int CredentialID { get; set; }
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? OTP { get; set; }
        public bool VerificationStatus { get; set; }
    }
}
