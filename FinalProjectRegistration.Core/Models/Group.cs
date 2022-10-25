namespace FinalProjectRegistration.Core.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Project { get; set; }
        public string ProjectDescription { get; set; }
        public List<Student> Students { get; set; }
        public Teacher Supervisor { get; set; }
    }

}
