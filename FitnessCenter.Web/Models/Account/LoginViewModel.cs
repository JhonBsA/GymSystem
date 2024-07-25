
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Web.Models
{
    public class LoginViewModel
    {   
        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}

