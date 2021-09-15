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

        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Cat>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cats)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
}
