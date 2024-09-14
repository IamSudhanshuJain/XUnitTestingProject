using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTechniques.Stubs
{
    public class StubUserAuthenticatedTrue : ICheckUserAuthenticated
    {
        public bool IsAuthenticated() => true;
    }
}
