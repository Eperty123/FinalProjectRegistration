using FinalProjectRegistration.Core.Models;

namespace FinalProjectRegistration.Domain.IRepositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> ReadAll();
        Student ReadById(int id);
        void Add(Student s);
        void Update(Student s);
        void Remove(Student s);
    }
}
