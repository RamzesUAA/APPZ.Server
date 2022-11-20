using APPZ.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace APPZ.Core
{
    public class MDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public MDBContext(DbContextOptions<MDBContext> options) : base(options)
        {
        }
        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }
        public DbSet<OrganisationNotifications> OrganisationNotifications { get; set; }
        public DbSet<OrganisationDetails> OrganisationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasMany(item => item.Notifications)
                .WithOne(item => item.User);
            //https://github.com/dotnet/efcore/issues/3815
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
