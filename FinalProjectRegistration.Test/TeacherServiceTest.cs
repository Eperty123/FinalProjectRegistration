using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Domain.IRepositories;
using FinalProjectRegistration.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/*
 * References:
 * https://github.com/bhp-SDM/DIProject_DK/blob/master/XUnitTestProject/StudentServiceTest.cs
 */

namespace FinalProjectRegistration.Test
{
    public class TeacherServiceTest
    {
        [Fact]
        public void TeacherService_Not_Null()
        {
            // Arrange
            Mock<ITeacherRepository> mockRepository = new Mock<ITeacherRepository>();
            ITeacherRepository repository = mockRepository.Object;

            // Act
            TeacherService service = new TeacherService(repository);

            // Assert
            Assert.NotNull(service);
            Assert.True(service is TeacherService);
        }

        [Fact]
        public void TeacherService_GetAll_Not_Null()
        {
            // Arrange

            Teacher[] fakeRepo = new Teacher[]
            {
                new Teacher() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                new Teacher() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };


            Mock<ITeacherRepository> mockRepository = new Mock<ITeacherRepository>();
            mockRepository.Setup(r => r.ReadAll()).Returns(fakeRepo);

            TeacherService service = new TeacherService(mockRepository.Object);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            mockRepository.Verify(r => r.ReadAll(), Times.Once);
        }

        [Theory]
        [InlineData(1, "Charlie", "USA", "hacker@hacker.com")] // First teacher with id 1.
        [InlineData(2, "Puth", "USA", "hacker@hacker.com")] // Second teacher with id 2.
        public void TeacherService_Add_Success(int id, string name, string address, string email)
        {
            // Arrange

            List<Teacher> fakeRepo = new List<Teacher>
            {
                //new Teacher() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                //new Teacher() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };

            var fakeTeacher = new Teacher() { Id = id, Name = name, Address = address, Email = email };

            Mock<ITeacherRepository> mockRepository = new Mock<ITeacherRepository>();
            mockRepository.Setup(r => r.Add(It.IsAny<Teacher>())).Callback<Teacher>(s => fakeRepo.Add(fakeTeacher));

            TeacherService service = new TeacherService(mockRepository.Object);

            // Act
            service.Add(fakeTeacher);

            // Assert
            Assert.True(fakeRepo.Count == 1); // one teacher inserted into the data list
            Assert.Equal(fakeTeacher, fakeRepo[0]); // and it is indeed the right teacher!
            mockRepository.Verify(r => r.Add(fakeTeacher), Times.Once);
        }

        [Theory]
        [InlineData(1)] // First teacher with id 1.
        [InlineData(2)] // Second teacher with id 2.
        public void TeacherService_GetById_Success(int id)
        {
            // Arrange

            Teacher[] fakeRepo = new Teacher[]
            {
                new Teacher() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                new Teacher() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };

            Mock<ITeacherRepository> mockRepository = new Mock<ITeacherRepository>();
            mockRepository.Setup(r => r.ReadById(id)).Returns(fakeRepo.FirstOrDefault(x => x.Id == id));

            TeacherService service = new TeacherService(mockRepository.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id == id);
            mockRepository.Verify(r => r.ReadById(id), Times.Once);
        }

        [Theory]
        [InlineData(1)] // First teacher with id 1.
        [InlineData(2)] // Second teacher with id 2.
        public void TeacherService_Remove_Success(int id)
        {
            // Arrange

            List<Teacher> fakeRepo = new List<Teacher>
            {
                new Teacher() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                new Teacher() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };

            var desiredTeacher = fakeRepo.FirstOrDefault(x => x.Id == id);

            Mock<ITeacherRepository> mockRepository = new Mock<ITeacherRepository>();
            mockRepository.Setup(r => r.Add(It.IsAny<Teacher>())).Callback<Teacher>(s => fakeRepo.Remove(desiredTeacher));

            TeacherService service = new TeacherService(mockRepository.Object);

            // Act
            service.Remove(desiredTeacher);

            // Assert
            Assert.Null(service.GetById(id));
            mockRepository.Verify(r => r.Remove(desiredTeacher), Times.Once);
        }

        [Theory]
        [InlineData(1, "Chester")] // First teacher with id 1.
        [InlineData(2, "Mike")] // Second teacher with id 2.
        public void TeacherService_Update_Success(int id, string name)
        {
            // Arrange

            List<Teacher> fakeRepo = new List<Teacher>
            {
                new Teacher() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                new Teacher() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };

            var desiredTeacher = fakeRepo.FirstOrDefault(x => x.Id == id);
            var index = fakeRepo.IndexOf(desiredTeacher);

            Mock<ITeacherRepository> mockRepository = new Mock<ITeacherRepository>();
            mockRepository.Setup(r => r.ReadById(id)).Returns(desiredTeacher);
            mockRepository.Setup(r => r.Update(It.IsAny<Teacher>())).Callback<Teacher>(s => fakeRepo[index] = desiredTeacher);

            TeacherService service = new TeacherService(mockRepository.Object);

            // Act
            desiredTeacher.Name = name;
            service.Update(desiredTeacher);

            // Assert
            Assert.NotNull(service.GetById(id));
            Assert.True(service.GetById(id).Name == name);
            mockRepository.Verify(r => r.Update(desiredTeacher), Times.Once);
        }
    }
}
