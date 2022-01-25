using BooksMVC.API.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using AppRepos = BooksMVC.Application.Repositories;
using DalRepos = BooksMVC.DAL.Repositories;

namespace BooksMVC.API.Tests
{
    public class BookControllerTests
    {
        //TODO implementation
        //private readonly ServiceProvider _serviceProvider;

        //public BookControllerTests(BooksController booksController)
        //{
        //    var services = new ServiceCollection();
        //    services.AddSingleton<BooksController>();
        //    services.AddSingleton<AppRepos.IBooksRepository, DalRepos.BooksRepository>();

        //    _serviceProvider = services.BuildServiceProvider();
        //}

        //[Fact]
        //public void Test1()
        //{
        //    var controller = _serviceProvider.GetService<BooksController>();
        //    controller.Get();
        //}
    }
}