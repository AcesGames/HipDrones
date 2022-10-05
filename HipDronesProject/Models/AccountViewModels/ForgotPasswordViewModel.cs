using System.ComponentModel.DataAnnotations;

namespace HipDronesProject.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
