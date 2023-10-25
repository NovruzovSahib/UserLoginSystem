using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserLoginSystem.Data
{
    public class MyDb:IdentityDbContext
    {
        public MyDb(DbContextOptions<MyDb> options) : base(options) { }


    }
}
