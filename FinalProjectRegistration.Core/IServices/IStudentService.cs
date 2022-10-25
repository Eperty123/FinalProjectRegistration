﻿using FinalProjectRegistration.Core.Models;

namespace FinalProjectRegistration.Core.IServices
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(Student s);
        void Update(Student s);
        void Remove(Student s);
    }
}
