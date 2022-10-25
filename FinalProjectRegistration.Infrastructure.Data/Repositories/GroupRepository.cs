using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Domain.IRepositories;
using FinalProjectRegistration.Infrastructure.Data.Utilities;

namespace FinalProjectRegistration.Infrastructure.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        readonly MainDbContext _mainDbContext;

        public GroupRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public void Add(Group s)
        {
            _mainDbContext.Groups.Add(s.ToEntity());
        }

        public IEnumerable<Group> ReadAll()
        {
            return _mainDbContext.Groups.Select(x => x.ToModel()).ToList();
        }

        public Group ReadById(int id)
        {
            return _mainDbContext.Groups.FirstOrDefault(x => x.Id == id).ToModel();
        }

        public void Remove(Group s)
        {
            var existing = _mainDbContext.Groups.FirstOrDefault(x => x.Id == s.Id);

            if (existing != null)
            {
                _mainDbContext.Groups.Remove(existing);
                _mainDbContext.SaveChanges();
            }
        }

        public void Update(Group s)
        {
            var existing = _mainDbContext.Groups.FirstOrDefault(x => x.Id == s.Id);

            if (existing != null)
            {
                //_mainDbContext.Groups.Update(existing);
                _mainDbContext.SaveChanges();
            }
        }
    }
}
