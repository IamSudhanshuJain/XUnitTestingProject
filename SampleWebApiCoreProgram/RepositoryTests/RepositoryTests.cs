using Infrastructure;
using Infrastructure.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace RepositoryTests
{

    public class RepositoryTests
    {
        private Repository<Department> _repository;
        private DbContextOptions<OrganizationContext> _dbOptions;
        private Mock<OrganizationContext> _organizationContext;
        private Mock<DbSet<Department>> _mockDepartment;
        public RepositoryTests()
        {
            _dbOptions = new DbContextOptions<OrganizationContext>();
            _organizationContext = new Mock<OrganizationContext>(_dbOptions);
            _mockDepartment = new Mock<DbSet<Department>>();
        }

        [Fact]
        public void GetRepository_Return_Result()
        {
            //Arrange
            int id = 1;
            _mockDepartment.Setup(x => x.Find(id)).Returns(new Department() { Id = 1, Name = "Engineering" });
            _organizationContext.Setup(x => x.Set<Department>()).Returns(_mockDepartment.Object);
            _repository = new Repository<Department>(_organizationContext.Object);

            //Act
            var actualResult = _repository.Get(id);

            //Assert
            Assert.Equal(1, actualResult.Id);

        }
        [Fact]
        public void AddRepository_Return_Result()
        {
            //Arrange
            int id = 2;
            var department= new Department() { Id = 2, Name = "Hr Operations" };
            _organizationContext.Setup(x => x.Add(department));
            _organizationContext.Setup(x => x.SaveChanges());

            _mockDepartment.Setup(x => x.Find(id)).Returns(department);
            _organizationContext.Setup(x => x.Set<Department>()).Returns(_mockDepartment.Object);
            _repository = new Repository<Department>(_organizationContext.Object);
            
            //Act

            _repository.Save(department);
            var actualResult = _repository.Get(id);

            //Assert
            Assert.Equal(id,actualResult.Id);
        }
        [Fact]
        public void UpdateRepository_Return_Result()
        {
            //Arrange
            int id = 2;
            var department = new Department() { Id = 2, Name = "Hr Operationss" };
            _organizationContext.Setup(x => x.Attach(department));
            _organizationContext.Setup(x => x.Update(department));
            _organizationContext.Setup(x => x.SaveChanges());

            _mockDepartment.Setup(x => x.Find(id)).Returns(department);
            _organizationContext.Setup(x => x.Set<Department>()).Returns(_mockDepartment.Object);
            _repository = new Repository<Department>(_organizationContext.Object);

            //Act

            _repository.Update(department);
            var actualResult = _repository.Get(id);

            //Assert
            Assert.Equal(id, actualResult.Id);
        }
        [Fact]
        public void DeleteRepository_Return_Result()
        {
            //Arrange
            int id = 2;
            var department = new Department() { Id = 2, Name = "Hr Operations" };
            _organizationContext.Setup(x => x.Add(department));
            _organizationContext.Setup(x => x.Remove(department));
            _organizationContext.Setup(x => x.SaveChanges());

            _mockDepartment.Setup(x => x.Find(id));
            _organizationContext.Setup(x => x.Set<Department>()).Returns(_mockDepartment.Object);
            _repository = new Repository<Department>(_organizationContext.Object);

            //Act
            _repository.Save(department);
            _repository.Delete(department);
            var actualResult = _repository.Get(id);

            //Assert
            Assert.Null(actualResult);
        }
    }
}
