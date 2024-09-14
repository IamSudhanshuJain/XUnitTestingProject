using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTechniques.Fakes
{
    public interface IUserRepository
    {
        void Insert(object user);
        List<object> GetAllUsers();
    }

}
