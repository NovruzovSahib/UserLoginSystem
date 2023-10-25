using System.ComponentModel.DataAnnotations;

namespace UserLoginSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="This field is required")]
        [EmailAddress(ErrorMessage ="Please enter valid email adress")]
        public string EmailAdress { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password is not the same")]
        public string ConfirmPassword { get; set; }
    }
}
