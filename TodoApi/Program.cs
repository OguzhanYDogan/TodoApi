using TodoApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(s => s.AddDefaultPolicy(
    p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddDbContext<TodoContext>(builder => builder.UseInMemoryDatabase("TodoList"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// D�Z�NLERDE index.html default yap�l�r
app.UseDefaultFiles();

// STAT�K DOSYALARIN UMUMA A�ILMASI (wwwroot)
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoContext>();
    db.Database.EnsureCreated();
}

    app.Run();


// Install-Package Microsoft.EntityFrameworkCore
// Install-Package Microsoft.EntityFrameworkCore.InMemory