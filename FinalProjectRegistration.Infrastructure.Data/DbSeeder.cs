namespace FinalProjectRegistration.Infrastructure.Data
{
    public class DbSeeder : IDbSeeder
    {
        readonly MainDbContext _context;

        public DbSeeder(MainDbContext mainDbContext)
        {
            _context = mainDbContext;
        }

        public void SeedDevelopment()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public void SeedProduction()
        {
            _context.Database.EnsureCreated();
        }
    }
}
