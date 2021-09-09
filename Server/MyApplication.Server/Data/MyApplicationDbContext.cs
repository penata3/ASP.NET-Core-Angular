namespace MyApplication.Server.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyApplication.Server.Data.Models;

    public class MyApplicationDbContext : IdentityDbContext<User>
    {
        public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
