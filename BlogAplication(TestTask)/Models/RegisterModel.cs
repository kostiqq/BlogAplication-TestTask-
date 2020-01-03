using System.ComponentModel.DataAnnotations;

namespace BlogAplication.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please type correct email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [DataType(DataType.Password)]
        [Compare("Pass", ErrorMessage = "Passwords must match ")]
        public string ConfirmPassword { get; set; }
    }
}
