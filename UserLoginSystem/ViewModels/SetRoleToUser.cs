using Microsoft.AspNetCore.Identity;

namespace UserLoginSystem.ViewModels
{
    public class SetRoleToUser
    {
        public string RoleId { get; set; }
        public string UserId { get; set; }

        public List<IdentityUser> UserList;

        public List<IdentityRole> RolerList;
    }
}
