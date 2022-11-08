using APPZ.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace APPZ.Migrations
{
    public class MDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public MDBContext(IConfiguration configuration)

        {
            Configuration = configuration;
        }
        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
