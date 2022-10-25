namespace FinalProjectRegistration.Infrastructure.Data.Entities
{
    public interface IPersonEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
