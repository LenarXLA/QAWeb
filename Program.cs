using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ArticleContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ArticleConection")));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Articles}/{action=Index}/{id?}");

app.Run();
