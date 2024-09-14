using Infrastructure.DomainEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleWebApiCore.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet]
        public Department Get()
        {
            return _departmentService.GetDetails(1);
        }

        [HttpPost("SaveDepartment")]
        public IActionResult SaveData(DepartmentRequest department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Department dept = new Department() { Name = department.Name, Description = department.Description };
            _departmentService.SaveInformation(dept);
            return Ok(dept);
        }
        [HttpPost("UpdateDepartment")]
        public IActionResult UpdateData(DepartmentRequest department, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Department dept = new Department() { Name = department.Name, Description = department.Description };
            _departmentService.UpdateInformation(dept,Id);
            var info  = _departmentService.GetDetails(Id);
            return Ok(info);

        }
    }
}
