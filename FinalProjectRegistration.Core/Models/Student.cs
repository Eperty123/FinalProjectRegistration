namespace FinalProjectRegistration.Core.Models
{
    public class Student : IPerson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
