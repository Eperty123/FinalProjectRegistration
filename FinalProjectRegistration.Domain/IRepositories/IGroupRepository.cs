using FinalProjectRegistration.Core.Models;

namespace FinalProjectRegistration.Domain.IRepositories
{
    public interface IGroupRepository
    {
        IEnumerable<Group> ReadAll();
        Group ReadById(int id);
        void Add(Group s);
        void Update(Group s);
        void Remove(Group s);
    }
}
