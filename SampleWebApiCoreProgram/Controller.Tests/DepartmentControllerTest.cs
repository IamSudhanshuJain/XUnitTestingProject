using Infrastructure.DomainEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SampleWebApiCore.Controllers;
using SampleWebApiCore.Models;
using Service;
using System;
using Xunit;

namespace Controller.Tests
{
    public class DepartmentControllerTest
    {
    
        private readonly Mock<IDepartmentService> _departmentService;
        private readonly DepartmentController _controller;
        public DepartmentControllerTest()
        {
          
            _departmentService=new Mock<IDepartmentService>();
            _controller = new DepartmentController(null, _departmentService.Object);
        }
        [Fact]
        public void GetDepartment_ReturnDepartment()
        {
            var department = new Department() { Id = 1, Name = "Engineering" };
            _departmentService.Setup(x => x.GetDetails(1)).Returns(department);

            var info = _controller.Get();

            Assert.Equal(department.Id, info.Id);
        }
        [Fact]
        public void SaveDepartment_with_emptyName_return_badRequest()
        {
            var department = new DepartmentRequest() { Name = String.Empty, Description = "engineering" };
            _controller.ModelState.AddModelError("Name", "The Name field is required");
            ObjectResult action = (ObjectResult)_controller.SaveData(department);
            Assert.IsType<BadRequestObjectResult>(action);
            Assert.Equal(400, action.StatusCode);
        }
        [Fact]
        public void SaveDepartment_With_GivenName_Return_OkResult()
        {
            var department = new DepartmentRequest() { Name = "Engineering", Description = "sasa" };
            ObjectResult action = (ObjectResult)_controller.SaveData(department);
            Assert.Equal(200, action.StatusCode);
        }

    }
}
