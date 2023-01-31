using Microsoft.EntityFrameworkCore;
using TestApp.API;
using TestApp.Core;
using TestApp.Infrastracture;
using TestApp.Infrastracture.DbServices.DbContext;
using TestApp.TestApp.Core.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<SeedData>();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext(builder.Configuration.GetConnectionString("SqlServer"));
builder.Services.AddIdentity();
builder.Services.AddRepositories();
builder.Services.RegisterServices();
builder.Services.AddAutoMapper(typeof(AppMapingProfile));
builder.Services.AddJwtAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()
              .WithOrigins("http://localhost:3000")
              .WithExposedHeaders()
          .SetIsOriginAllowed(isOriginAllowed => true));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
        var seedData = services.GetRequiredService<SeedData>();
        await seedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
}

app.MapControllers();

app.Run();
