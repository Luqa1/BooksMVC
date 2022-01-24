namespace BooksMVC
{
    public static class ServicesRegistrator
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //TODO register DAL, to do that repositories should be moved to separate module.
            //services.RegisterDalServices();
        }
    }
}
