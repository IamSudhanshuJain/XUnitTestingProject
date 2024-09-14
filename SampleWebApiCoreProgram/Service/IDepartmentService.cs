using Infrastructure.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDepartmentService
    {
        Department GetDetails(int i);
        void SaveInformation(Department department);
        void UpdateInformation(Department department, int Id);
    }
}
