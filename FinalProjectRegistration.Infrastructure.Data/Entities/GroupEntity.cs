namespace FinalProjectRegistration.Infrastructure.Data.Entities
{
    public class GroupEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Project { get; set; }
        public string ProjectDescription { get; set; }
        public List<StudentEntity> Students { get; set; }
        public TeacherEntity Supervisor { get; set; }
    }
}
