using BooksMVC.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookMVC.DAL
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
