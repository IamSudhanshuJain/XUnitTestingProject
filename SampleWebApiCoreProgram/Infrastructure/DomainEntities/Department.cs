using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DomainEntities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Function> Functions { get;}
    }
}
