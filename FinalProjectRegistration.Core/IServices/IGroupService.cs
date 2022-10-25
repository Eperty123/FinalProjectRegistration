using FinalProjectRegistration.Core.Models;

namespace FinalProjectRegistration.Core.IServices
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
        Group GetById(int id);
        void Add(Group s);
        void Update(Group s);
        void Remove(Group s);
    }
}
