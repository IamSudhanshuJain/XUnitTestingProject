using Infrastructure;
using Infrastructure.DomainEntities;
using System;

namespace Service
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;
        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }

        public Department GetDetails(int i)
        {
            return _departmentRepository.Get(i);
        }

        public void SaveInformation(Department department)
        {
            _departmentRepository.Save(department);
        }
        public void UpdateInformation(Department department, int Id)
        {
            var existing = _departmentRepository.Get(Id);
            if (existing != null)
            {
                existing.Name = department.Name;
                existing.Description = department.Description;  
                _departmentRepository.Update(existing);
            }
        }
        public void DeleteDepartment(int id)
        {
            var existing = _departmentRepository.Get(id);
            if (existing != null)
            {
                _departmentRepository.Delete(existing);
            }
        }
    }
}
