using FinalProjectRegistration.Core.Models;

namespace FinalProjectRegistration.Domain.IRepositories
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> ReadAll();
        Teacher ReadById(int id);
        void Add(Teacher t);
        void Update(Teacher t);
        void Remove(Teacher t);
    }
}
