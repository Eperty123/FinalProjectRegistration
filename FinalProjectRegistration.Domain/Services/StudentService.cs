using FinalProjectRegistration.Core.IServices;
using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Domain.IRepositories;

namespace FinalProjectRegistration.Domain.Services
{
    public class StudentService : IStudentService
    {
        readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Add(Student s)
        {
            _studentRepository.Add(s);
        }

        public IEnumerable<Student> GetAll()
        {
            return _studentRepository.ReadAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.ReadById(id);
        }

        public void Remove(Student s)
        {
            _studentRepository.Remove(s);
        }

        public void Update(Student s)
        {
            _studentRepository.Update(s);
        }
    }
}
