using Microsoft.EntityFrameworkCore;
using ReadCNAB.Data;
using ReadCNAB.Repository;
using ReadCNAB.Repository.Transaction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConnectionDB>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddTransient<ICNABRepository, CNABRepository>();
builder.Services.AddTransient<ITranRepository, TranRepository>();

var app = builder.Build();

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
