using Infrastructure.DomainEntities;
using Moq;
using Moq.Protected;
using Service;
using Service.Test.MockRepositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Test
{

    public class DepartmentServiceTest
    {


        public Mock<IRepository<Department>> departmentRepository;
        public IRepository<Department> fakeDepartmentRepository;
        public DepartmentService departmentService;

        public static IEnumerable<object[]> departmentDataProperty => new List<object[]> { new object[] { 1, "Hr Engineering" },
         new object[] { 2, "Hr Operations" }};
        public DepartmentServiceTest()
        {
            departmentRepository = new Mock<IRepository<Department>>();
            fakeDepartmentRepository = new FakeRepository();
        }

        [Fact]
        public void GetDepartmentBasedOnId_Return_DepartmentInformation()
        {
            //Arrange
            var department = new Department() { Id = 1, Name = "Engineering" };
            departmentService = new DepartmentService(departmentRepository.Object);

            //Setup
            departmentRepository.Setup(d => d.Get(It.IsAny<int>())).Returns(() => new Department() { Id = 1, Name= "Engineering" });

            //Act    
            var departmentData = departmentService.GetDetails(1);

            //Assert
            Assert.Equal(departmentData.Name, department.Name);
            department = null;
            Assert.Throws<NullReferenceException>(() => GetDepartment());

        }

        private Department GetDepartment()
        {
            throw new NullReferenceException();
        }

        [Fact]
        public void usingFakeDepartmentRepository_Return_DepartmentInformation()
        {
            //Arrange
            var data = new Department() { Id = 1, Name = "Engineering" };
            departmentService = new DepartmentService(fakeDepartmentRepository);

            //Setup
            fakeDepartmentRepository.Save(data);

            //Act
            var departmentData = departmentService.GetDetails(1);

            //Assert
            Assert.Equal(data.Id, departmentData.Id);
        }

        [Fact]
        public void UpdateDepartment_BasedOnId_ReturnUpdatedData()
        {
            //Arrange
            var updatedData = new Department() { Id = 1, Name = "HR Operations" };
            departmentService = new DepartmentService(departmentRepository.Object);

            //Setup
            departmentRepository.Setup(x => x.Update(updatedData));
            departmentRepository.Setup(x => x.Get(1)).Returns(updatedData);
            departmentRepository.Setup(x => x.Get(2)).Returns(updatedData);

            //Act
            departmentService.UpdateInformation(updatedData, 1);
            var getData = departmentService.GetDetails(1);
            //Assert
            Assert.Equal(getData.Name, updatedData.Name);
        }

       

        [Theory]
        [ClassData(typeof(DepartmentData))]
        public void UpdateDepartment_UsingMemberData_BasedOnId_ReturnUpdatedData(int id, string name)
        {
            //Arrange
            var updatedData = new Department() { Id = id, Name = name };
            departmentService = new DepartmentService(departmentRepository.Object);

            //Setup
            departmentRepository.Setup(x => x.Update(updatedData));
            departmentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(updatedData);

            //Act
            departmentService.UpdateInformation(updatedData, 1);
            var getData = departmentService.GetDetails(1);
            //Assert
            Assert.Equal(getData.Name, updatedData.Name);
        }



        [Fact]
        public async void GetContentSizeReturnsCorrectLength()
        {
            // Arrange
            const string testContent = "test content";
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            var underTest = new SiteAnalyzer(new HttpClient(mockMessageHandler.Object));

            // Act
            var result = await underTest.GetContentSize("http://anyurl");

            // Assert
            Assert.Equal(testContent.Length, result);
        }
    }

    internal class DepartmentData : IEnumerable<object[]>
    {

        private readonly int Id = 1;
        private readonly string Name = "HR Operationss";

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
        {
            yield return new object[] { Id, Name };
        }

        //IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
