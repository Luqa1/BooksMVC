using BooksMVC.API.Controllers;
using BooksMVC.API.ViewModel;
using BooksMVC.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using DalRepos = BooksMVC.DAL.Repositories;

namespace BooksMVC.API.Tests
{
    public class BookControllerTests
    {
        private readonly BooksController _booksController = 
            new BooksController(
                new Logger<BooksController>(new LoggerFactory()), 
                new DalRepos.BooksRepository(new BooksContext(true)));

        [Fact]
        public void GetAllBooks_TestCountOFResultCollection_ShouldContain2()
        {
            if (_booksController.Get().Result is OkObjectResult okObjectResult)
            {
                if (okObjectResult.Value is IEnumerable<BookVm> bookVms)
                {
                    Assert.True(bookVms.Count() == 2);
                }
                else
                    Assert.True(false);
            }
            else
                Assert.True(false);
        }

        [Fact]
        public void GetBook_TestNotFound_ShouldReturnNotFoundResult()
        {
            if (_booksController.Get(9999).Result is NotFoundResult)
                Assert.True(true);
            else
                Assert.True(false);
        }

        [Fact]
        public void GetBook_TestNotFound_ShouldReturnOkdResult()
        {
            if (_booksController.Get(1).Result is OkObjectResult)
                Assert.True(true);
            else
                Assert.True(false);
        }
    }
}