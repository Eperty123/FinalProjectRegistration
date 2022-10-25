using FinalProjectRegistration.Core.IServices;
using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Domain.IRepositories;

namespace FinalProjectRegistration.Domain.Services
{
    public class TeacherService : ITeacherService
    {
        readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void Add(Teacher t)
        {
            _teacherRepository.Add(t);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _teacherRepository.ReadAll();
        }

        public Teacher GetById(int id)
        {
            return _teacherRepository.ReadById(id);
        }

        public void Remove(Teacher t)
        {
            _teacherRepository.Remove(t);
        }

        public void Update(Teacher t)
        {
            _teacherRepository.Update(t);
        }
    }
}
