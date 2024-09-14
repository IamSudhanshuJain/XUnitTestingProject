using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTechniques.Stubs
{
    public class UserAuthenticated : ICheckUserAuthenticated
    {
        public bool IsAuthenticated()
        {
            //Call Active Directory and get response
            

            //Based on the conditions decide authentication

            return true;

        }
    }
}
