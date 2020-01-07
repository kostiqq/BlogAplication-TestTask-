using System.ComponentModel.DataAnnotations;

namespace BlogAplication.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please type correct email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match ")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
