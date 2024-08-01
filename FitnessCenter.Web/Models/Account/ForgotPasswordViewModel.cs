using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
    }
}
