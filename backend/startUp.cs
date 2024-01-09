services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));