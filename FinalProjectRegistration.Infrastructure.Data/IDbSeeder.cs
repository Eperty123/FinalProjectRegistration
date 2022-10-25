namespace FinalProjectRegistration.Infrastructure.Data
{
    public interface IDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}
