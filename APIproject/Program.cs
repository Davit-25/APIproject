using APIproject;
using  Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductManagmentContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductManagmentDB")));

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    using var dbContext = scope.ServiceProvider.GetRequiredService<ProductManagmentContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
