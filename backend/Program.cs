
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
//* Configurar a conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "User Management API", Version = "v1" });
});


builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API v1"));
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();
app.Run();