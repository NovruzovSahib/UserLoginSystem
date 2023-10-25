using System.ComponentModel.DataAnnotations;

namespace UserLoginSystem.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is required"), StringLength(20)]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required"), StringLength(10),DataType(DataType.Password)]
        public string Password { get; set; }= string.Empty;
        public bool RememberMe { get; set; }
    }
}
