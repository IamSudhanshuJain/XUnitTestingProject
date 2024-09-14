using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingTechniques.Mocks;

namespace TestingTechniques.Tests.Fakes
{
    public class AccountServiceTest
    {
        /// <summary>
        /// First Moq Test
        /// </summary>
        [Fact]
        public void GetAllBooksForCategory_returns_list_of_available_books()
        {
            //1
            var bookServiceStub = new Mock<IBookService>();
            //2
            bookServiceStub
                .Setup(x => x.GetBooksForCategory("UnitTesting"))
                .Returns(new List<string>
                {
            "The Art of Unit Testing",
            "Test-Driven Development",
            "Working Effectively with Legacy Code"
                });
            //3
            var accountService = new AccountService(bookServiceStub.Object, null);
            IEnumerable<string> result = accountService.GetAllBooksForCategory("UnitTesting");
            Assert.Equal(3, result.Count());
        }

        /// <summary>
        /// Set up mutple methods on a stub
        /// </summary>
        [Fact]
        public void GetBookISBN_founds_the_correct_book_for_search_term()
        {
            var bookServiceStub = new Mock<IBookService>();
            //1
            bookServiceStub
                .Setup(x => x.GetBooksForCategory("UnitTesting"))
                .Returns(new List<string>
                {
            "The Art of Unit Testing",
            "Test-Driven Development",
            "Working Effectively with Legacy Code"
                });
            //2
            bookServiceStub
                .Setup(x => x.GetISBNFor("The Art of Unit Testing"))
                .Returns("0-9020-7656-6");
            var accountService = new AccountService(bookServiceStub.Object, null);
            string result = accountService.GetBookISBN("UnitTesting", "art");
            Assert.Equal("0-9020-7656-6", result);
        }

        /// <summary>
        /// Ignore input parameters in Moq
        /// </summary>
        [Fact]
        public void GetAllBooksForCategory_returns_list_of_available_books_IgnoreInputParameters()
        {
            //1
            string passedParameter = string.Empty;
            var bookServiceStub = new Mock<IBookService>();
            //2
            bookServiceStub
                  .Setup(x => x.GetBooksForCategory(It.IsAny<string>()))
                  .Callback<string>(s => passedParameter = s)
                  .Returns(new List<string>
                  {
                     "The Art of Unit Testing",
                     "Test-Driven Development",
                     "Working Effectively with Legacy Code"
                  });
            //3
            var accountService = new AccountService(bookServiceStub.Object, null);
            IEnumerable<string> result = accountService.GetAllBooksForCategory("UnitTesting");
            Assert.Equal(3, result.Count());
        }


        /// <summary>
        /// Throw Exception
        /// </summary>
        [Fact]
        public void GetAllBooksForCategory_ThrowException()
        {
            //1
            string passedParameter = string.Empty;
            var bookServiceStub = new Mock<IBookService>();
            //2
            bookServiceStub
                .Setup(x => x.GetBooksForCategory(It.IsAny<string>()))
                .Throws<InvalidOperationException>();
            //3
            var accountService = new AccountService(bookServiceStub.Object, null);
            Assert.Throws<InvalidOperationException>(()=> accountService.GetAllBooksForCategory("UnitTesting"));

        }

        /// <summary>
        /// With Callback
        /// </summary>
        [Fact]
        public void GetAllBooksForCategory_returns_list_of_available_books_with_callback()
        {
            var bookServiceStub = new Mock<IBookService>();
            string passedParameter = string.Empty;
            bookServiceStub
            .Setup(x => x.GetBooksForCategory(It.IsAny<string>()))
            .Callback<string>(s => passedParameter = s)
            .Returns(new List<string>
            {
    "The Art of Unit Testing",
    "Test-Driven Development",
    "Working Effectively with Legacy Code"
            });
            var accountService = new AccountService(bookServiceStub.Object, null);
            IEnumerable<string> result = accountService.GetAllBooksForCategory("UnitTesting");
            Assert.Equal("UnitTesting", passedParameter);
        }

        /// <summary>
        /// Sequential Calls
        /// </summary>

        [Fact]
        public void GetBookISBN_founds_the_correct_book_for_search_term_WithSequentialCalls()
        {
            var bookServiceStub = new Mock<IBookService>();
            //1
            bookServiceStub
                .Setup(x => x.GetBooksForCategory("UnitTesting"))
                .Returns(new List<string>
                {
            "The Art of Unit Testing",
            "Test-Driven Development",
            "Working Effectively with Legacy Code"
                });
            //2
            bookServiceStub
                      .SetupSequence(x => x.GetISBNFor(It.IsAny<string>()))
                      .Returns("0-9020-7656-6") //returned on 1st call
                      .Returns("0-9180-6396-5") //returned on 2nd call
                      .Returns("0-3860-1173-7") //returned on 3rd call
                      .Returns("0-5570-1450-6");//returned on 4th call
            var accountService = new AccountService(bookServiceStub.Object, null);
            string result = accountService.GetBookISBN("UnitTesting", "art");
            Assert.Equal("0-9020-7656-6", result);
        }


        /// <summary>
        /// Verify Expectations
        /// </summary>
        [Fact]
        public void SendEmail_sends_email_with_correct_content()
        {
            //1
            var emailSenderMock = new Mock<IEmailSender>();
            //2
            var accountService = new AccountService(null, emailSenderMock.Object);
            //3
            accountService.SendEmail("test@gmail.com", "Test - Driven Development");
            //4
            emailSenderMock.Verify(x => x.SendEmail("test@gmail.com", "Awesome Book", $"Hi,\n\nThis book is awesome: Test - Driven Development.\nCheck it out."), Times.Once);
        }

    }
}
