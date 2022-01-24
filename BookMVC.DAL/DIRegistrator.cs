using BooksMVC.Application.Repositories;
using BooksMVC.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BooksMVC.DAL
{
    public static class DIRegistrator
    {
        public static void RegisterDalServices(this IServiceCollection services)
        {
            services.AddSingleton<BooksContext>();
            services.AddScoped<IBooksRepository, BooksRepository>();
        }
    }
}
