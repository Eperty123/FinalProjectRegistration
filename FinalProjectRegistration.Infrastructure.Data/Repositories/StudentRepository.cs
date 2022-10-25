using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectRegistration.Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public void Add(Student s)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Student ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Student s)
        {
            throw new NotImplementedException();
        }

        public void Update(Student s)
        {
            throw new NotImplementedException();
        }
    }
}
