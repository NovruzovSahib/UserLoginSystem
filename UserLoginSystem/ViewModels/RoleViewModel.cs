using System.ComponentModel.DataAnnotations;

namespace UserLoginSystem.ViewModels
{
    public class RoleViewModel
    {
        public string RoleId { get; set; }=string.Empty;
        [Required(ErrorMessage ="This field is required"),StringLength(20)]
        public string RoleName { get; set; }=string.Empty;
    }
}
