using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTechniques.Tests.Fakes
{
    public class UserTest
    {
        public FakeRepository _fakeRepository;

        [Fact]
        public void GetAllUsers_ReturnAllUserObject()
        {
            List<object> expected = new List<object> {"Tom", "James", "Hilton", "Marry" };
            object User1 = "Tom";
            object User2 = "Marry";
            object User3 = "Hilton";
            object User4 = "James";


            //Arrange
            _fakeRepository = new FakeRepository();

            
            //Act
            _fakeRepository.Insert(User1);
            _fakeRepository.Insert(User2);
            _fakeRepository.Insert(User3);
            _fakeRepository.Insert(User4);

            var actual = _fakeRepository.GetAllUsers();

            //Assert
            Assert.NotNull(actual); 
            Assert.Equal(expected.Count, actual.Count);

        }
    }
}
