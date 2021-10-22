namespace MyApplication.Server.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MyApplication.Server.Data.Models;
    using MyApplication.Server.Data.Models.Base;
    using MyApplication.Server.Infrastructure.Services;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class MyApplicationDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUser;

        public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options,
            ICurrentUserService currentUser)
            : base(options)
        {
            this.currentUser = currentUser;
        }

        public DbSet<Cat> Cats { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAudtitInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.ApplyAudtitInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Cat>()
                .HasQueryFilter(c => !c.isDeleted)
                .HasOne(c => c.User)                 
                .WithMany(u => u.Cats)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }

        private void ApplyAudtitInformation()
            => this.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry =>
        {
            var userName = this.currentUser.GetUsername();

            if (entry.Entity is IDeletableEntity deletableEntity)
            {
                if (entry.State == EntityState.Deleted)
                {
                    deletableEntity.isDeleted = true;
                    deletableEntity.DeletedBy = userName;
                    deletableEntity.DeletedOn = DateTime.UtcNow;
                    entry.State = EntityState.Modified;

                    return;
                }
            }

            if (entry.Entity is IEntity entity)
            {
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.CreatedBy = this.currentUser.GetUsername();
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedOn = DateTime.Now;
                    entity.ModifiedBy = this.currentUser.GetUsername();
                }
            }
        });
  
    }
}
