using FinalProjectRegistration.Core.Models;

namespace FinalProjectRegistration.Core.IServices
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Add(Teacher t);
        void Update(Teacher t);
        void Remove(Teacher t);
    }
}
