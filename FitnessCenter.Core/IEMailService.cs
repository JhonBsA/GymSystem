namespace FitnessCenter.Core
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}

