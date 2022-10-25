using FinalProjectRegistration.Core.Models;
using FinalProjectRegistration.Domain.IRepositories;
using FinalProjectRegistration.Domain.Services;
using Moq;

namespace FinalProjectRegistration.Test
{
    public class GroupServiceTest
    {
        [Fact]
        public void GroupService_Not_Null()
        {
            // Arrange
            Mock<IGroupRepository> mockRepository = new Mock<IGroupRepository>();
            IGroupRepository repository = mockRepository.Object;

            // Act
            GroupService service = new GroupService(repository);

            // Assert
            Assert.NotNull(service);
            Assert.True(service is GroupService);
        }

        [Fact]
        public void GroupService_GetAll_Not_Null()
        {
            // Arrange

            Group[] fakeRepo = new Group[]
            {
                new Group() { Id = 1, Name = "Gruppe A", Project = "Test"},
                new Group() { Id = 2, Name = "Grupppe B", Project = "Test 2"}
            };


            Mock<IGroupRepository> mockRepository = new Mock<IGroupRepository>();
            mockRepository.Setup(r => r.ReadAll()).Returns(fakeRepo);

            GroupService service = new GroupService(mockRepository.Object);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Any());
            mockRepository.Verify(r => r.ReadAll(), Times.Once);
        }

        [Theory]
        [InlineData(1, "Gruppe A", "Latin")] // First group with id 1.
        [InlineData(2, "Gruppe B", "Engelsk")] // Second group with id 2.
        public void GroupService_Add_Success(int id, string name, string project)
        {
            // Arrange

            List<Group> fakeRepo = new List<Group>
            {
                //new Group() { Id = 1, Name = "Gruppe A", Project = "Test"},
                //new Group() { Id = 2, Name = "Grupppe B", Project = "Test 2"}
            };

            var fakeGroup = new Group() { Id = id, Name = name, Project = project };

            Mock<IGroupRepository> mockRepository = new Mock<IGroupRepository>();
            mockRepository.Setup(r => r.Add(It.IsAny<Group>())).Callback<Group>(s => fakeRepo.Add(fakeGroup));

            GroupService service = new GroupService(mockRepository.Object);

            // Act
            service.Add(fakeGroup);

            // Assert
            Assert.True(fakeRepo.Count == 1); // one group inserted into the data list
            Assert.Equal(fakeGroup, fakeRepo[0]); // and it is indeed the right group!
            mockRepository.Verify(r => r.Add(fakeGroup), Times.Once);
        }

        [Theory]
        [InlineData(1)] // First group with id 1.
        [InlineData(2)] // Second group with id 2.
        public void GroupService_GetById_Success(int id)
        {
            // Arrange

            Group[] fakeRepo = new Group[]
            {
                new Group() { Id = 1, Name = "Gruppe A", Project = "Test"},
                new Group() { Id = 2, Name = "Grupppe B", Project = "Test 2"}
            };

            Mock<IGroupRepository> mockRepository = new Mock<IGroupRepository>();
            mockRepository.Setup(r => r.ReadById(id)).Returns(fakeRepo.FirstOrDefault(x => x.Id == id));

            GroupService service = new GroupService(mockRepository.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id == id);
            mockRepository.Verify(r => r.ReadById(id), Times.Once);
        }

        [Theory]
        [InlineData(1)] // First group with id 1.
        [InlineData(2)] // Second group with id 2.
        public void GroupService_Remove_Success(int id)
        {
            // Arrange

            List<Group> fakeRepo = new List<Group>
            {
                new Group() { Id = 1, Name = "Gruppe A", Project = "Test"},
                new Group() { Id = 2, Name = "Grupppe B", Project = "Test 2"}
            };

            var desiredGroup = fakeRepo.FirstOrDefault(x => x.Id == id);

            Mock<IGroupRepository> mockRepository = new Mock<IGroupRepository>();
            mockRepository.Setup(r => r.Add(It.IsAny<Group>())).Callback<Group>(s => fakeRepo.Remove(desiredGroup));

            GroupService service = new GroupService(mockRepository.Object);

            // Act
            service.Remove(desiredGroup);

            // Assert
            Assert.Null(service.GetById(id));
            mockRepository.Verify(r => r.Remove(desiredGroup), Times.Once);
        }

        [Theory]
        [InlineData(1, "Gruppe A", "Latin")] // First group with id 1.
        [InlineData(2, "Gruppe B", "Engelsk")] // Second group with id 2.
        public void GroupService_Update_Success(int id, string name, string project)
        {
            // Arrange

            List<Group> fakeRepo = new List<Group>
            {
                new Group() { Id = 1, Name = "Gruppe A", Project = "Test"},
                new Group() { Id = 2, Name = "Grupppe B", Project = "Test 2"}
            };

            var desiredGroup = fakeRepo.FirstOrDefault(x => x.Id == id);
            var index = fakeRepo.IndexOf(desiredGroup);

            Mock<IGroupRepository> mockRepository = new Mock<IGroupRepository>();
            mockRepository.Setup(r => r.ReadById(id)).Returns(desiredGroup);
            mockRepository.Setup(r => r.Update(It.IsAny<Group>())).Callback<Group>(s => fakeRepo[index] = desiredGroup);

            GroupService service = new GroupService(mockRepository.Object);

            // Act
            desiredGroup.Name = name;
            desiredGroup.Project = project;
            service.Update(desiredGroup);

            // Assert
            Assert.NotNull(service.GetById(id));
            Assert.True(service.GetById(id).Name == name);
            Assert.True(service.GetById(id).Project == project);
            mockRepository.Verify(r => r.Update(desiredGroup), Times.Once);
        }
    }
}
