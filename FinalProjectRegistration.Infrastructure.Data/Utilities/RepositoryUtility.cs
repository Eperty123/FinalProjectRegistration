using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Infrastructure.Data.Entities;

namespace FinalProjectRegistration.Infrastructure.Data.Utilities
{
    public static class RepositoryUtility
    {
        public static GroupEntity ToEntity(this Group group)
        {
            return new GroupEntity
            {
                Id = group.Id,
                Name = group.Name,
                Project = group.Project,
                ProjectDescription = group.ProjectDescription,
                Students = group.Students.Select(s => new StudentEntity
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Email = s.Email,
                }).ToList(),
                Supervisor = new TeacherEntity
                {
                    Id = group.Supervisor.Id,
                    Name = group.Supervisor.Name,
                    Address = group.Supervisor.Address,
                    Email = group.Supervisor.Email,
                }
            };
        }

        public static Group ToModel(this GroupEntity group)
        {
            return new Group
            {
                Id = group.Id,
                Name = group.Name,
                Project = group.Project,
                ProjectDescription = group.ProjectDescription,
                Students = group.Students.Select(s => new Student
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    Email = s.Email,
                }).ToList(),
                Supervisor = new Teacher
                {
                    Id = group.Supervisor.Id,
                    Name = group.Supervisor.Name,
                    Address = group.Supervisor.Address,
                    Email = group.Supervisor.Email,
                }
            };
        }
    }
}
