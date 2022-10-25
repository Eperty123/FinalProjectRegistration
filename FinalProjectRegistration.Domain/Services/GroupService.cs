using FinalProjectRegistration.Core.IServices;
using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Domain.IRepositories;

namespace FinalProjectRegistration.Domain.Services
{
    public class GroupService : IGroupService
    {
        readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public void Add(Group s)
        {
            _groupRepository.Add(s);
        }

        public IEnumerable<Group> GetAll()
        {
            return _groupRepository.ReadAll();
        }

        public Group GetById(int id)
        {
            return _groupRepository.ReadById(id);
        }

        public void Remove(Group s)
        {
            _groupRepository.Remove(s);
        }

        public void Update(Group s)
        {
            _groupRepository.Update(s);
        }
    }
}
