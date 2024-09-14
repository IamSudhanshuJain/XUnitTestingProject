using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTechniques.Fakes
{
  
    public class UserRepository : IUserRepository
    {
        public List<object> GetAllUsers()
        {
            //Go to the database and fetch all users. 
            return new List<object>(); 
  
        }

        public void Insert(object user)
        {
            //Insert a user into the database here. 
        }
    }
}
