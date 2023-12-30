using System.ComponentModel.DataAnnotations;

namespace Demo.PL.ViewModel
{
    public class RegisterVM
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Mail")]
        [Required(ErrorMessage = "This Field Pequred")]
        public string? Email { get; set; }

        //[Required(ErrorMessage = "This Field Pequred")]
        //[MinLength(6, ErrorMessage = "Min len 6")]
        //[DataType(DataType.Password)]
        public string? Password { get; set; }

        //[Required(ErrorMessage = "This Field Pequred")]
        //[MinLength(6, ErrorMessage = "Min len 6")]
        //[Compare("Password", ErrorMessage = "Password Not Match")]
        //[DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
        
    }
}
