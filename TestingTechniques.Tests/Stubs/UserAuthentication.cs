using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTechniques.Stubs;

namespace TestingTechniques.Tests.Fakes
{
    public class UserAuthentication
    {
        public StubUserAuthenticatedTrue? _UserAuthenticated;

        [Fact]
        public void IsAuthenticated_ReturnTrue()
        {
            //Arrange
            _UserAuthenticated = new StubUserAuthenticatedTrue();

            //Act and Assert
            Assert.True(_UserAuthenticated.IsAuthenticated());

        }
    }
}
