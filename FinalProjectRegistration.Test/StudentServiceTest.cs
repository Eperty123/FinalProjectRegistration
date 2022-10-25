using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Domain.IRepositories;
using FinalProjectRegistration.Domain.Services;
using Moq;

namespace FinalProjectRegistration.Test
{
    public class StudentServiceTest
    {
        [Fact]
        public void StudentService_Not_Null()
        {
            // Arrange
            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            IStudentRepository repository = mockRepository.Object;

            // Act
            StudentService service = new StudentService(repository);

            // Assert
            Assert.NotNull(service);
            Assert.True(service is StudentService);
        }

        [Fact]
        public void StudentService_GetAll_Not_Null()
        {
            // Arrange

            Student[] fakeRepo = new Student[]
            {
                new Student() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                new Student() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };


            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(r => r.ReadAll()).Returns(fakeRepo);

            StudentService service = new StudentService(mockRepository.Object);

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
        public void StudentService_Add_Success(int id, string name, string address, string email)
        {
            // Arrange

            List<Student> fakeRepo = new List<Student>
            {
                //new Student() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                //new Student() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };

            var fakeStudent = new Student() { Id = id, Name = name, Address = address, Email = email };

            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(r => r.Add(It.IsAny<Student>())).Callback<Student>(s => fakeRepo.Add(fakeStudent));

            StudentService service = new StudentService(mockRepository.Object);

            // Act
            service.Add(fakeStudent);

            // Assert
            Assert.True(fakeRepo.Count == 1); // one teacher inserted into the data list
            Assert.Equal(fakeStudent, fakeRepo[0]); // and it is indeed the right teacher!
            mockRepository.Verify(r => r.Add(fakeStudent), Times.Once);
        }

        [Theory]
        [InlineData(1)] // First teacher with id 1.
        [InlineData(2)] // Second teacher with id 2.
        public void StudentService_GetById_Success(int id)
        {
            // Arrange

            Student[] fakeRepo = new Student[]
            {
                new Student() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                new Student() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };

            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(r => r.ReadById(id)).Returns(fakeRepo.FirstOrDefault(x => x.Id == id));

            StudentService service = new StudentService(mockRepository.Object);

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
        public void StudentService_Remove_Success(int id)
        {
            // Arrange

            List<Student> fakeRepo = new List<Student>
            {
                new Student() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                new Student() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };

            var desiredStudent = fakeRepo.FirstOrDefault(x => x.Id == id);

            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(r => r.Add(It.IsAny<Student>())).Callback<Student>(s => fakeRepo.Remove(desiredStudent));

            StudentService service = new StudentService(mockRepository.Object);

            // Act
            service.Remove(desiredStudent);

            // Assert
            Assert.Null(service.GetById(id));
            mockRepository.Verify(r => r.Remove(desiredStudent), Times.Once);
        }

        [Theory]
        [InlineData(1, "Chester")] // First teacher with id 1.
        [InlineData(2, "Mike")] // Second teacher with id 2.
        public void StudentService_Update_Success(int id, string name)
        {
            // Arrange

            List<Student> fakeRepo = new List<Student>
            {
                new Student() { Id = 1, Name = "Charlie", Address = "USA", Email = "hacker@hacker.com"},
                new Student() { Id = 2, Name = "Puth", Address = "USA", Email = "hacker@hacker.com"}
            };

            var desiredStudent = fakeRepo.FirstOrDefault(x => x.Id == id);
            var index = fakeRepo.IndexOf(desiredStudent);

            Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(r => r.ReadById(id)).Returns(desiredStudent);
            mockRepository.Setup(r => r.Update(It.IsAny<Student>())).Callback<Student>(s => fakeRepo[index] = desiredStudent);

            StudentService service = new StudentService(mockRepository.Object);

            // Act
            desiredStudent.Name = name;
            service.Update(desiredStudent);

            // Assert
            Assert.NotNull(service.GetById(id));
            Assert.True(service.GetById(id).Name == name);
            mockRepository.Verify(r => r.Update(desiredStudent), Times.Once);
        }
    }
}