using FinalProjectRegistration.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectRegistration.Infrastructure.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
