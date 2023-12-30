using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModel
{
    public class ForgetPasswordVM
    {
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Pequred")]
        public string? Email { get; set; }
    }
}
