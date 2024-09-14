using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTechniques.Fakes;

namespace TestingTechniques.Tests.Fakes
{
    public class FakeRepository : IUserRepository
    {
        public List<object> Users { get; set; }
        public FakeRepository()
        {
            Users = new List<object>();
        }
        public List<object> GetAllUsers()
        {
            return Users;
        }

        public void Insert(object user)
        {
            Users.Add(user);
        }
    }
}
