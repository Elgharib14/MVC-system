using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModel
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Pequred")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "This Field Pequred")]
        [MinLength(6, ErrorMessage = "Min len 6")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool Rememberme { get; set; }
    }
}
