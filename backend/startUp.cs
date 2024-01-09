public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

    // ...
}