using Infrastructure;
using Infrastructure.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Test.MockRepositories
{
    public class FakeRepository : IRepository<Department>
    {
        public List<Department> departmentContext;
        public FakeRepository()
        {
            departmentContext = new List<Department>();
        }

        public void Delete(Department data)
        {
            throw new NotImplementedException();
        }

        public Department Get(object Id)
        {
            return departmentContext.Find(x=>x.Id == (int)Id);
        }

        public void Save(Department department)
        {
            departmentContext.Add(department);
        }

        public void Update(Department Data)
        {
            throw new NotImplementedException();
        }
    }
}
