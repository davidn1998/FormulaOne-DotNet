using FormulaOne.Api.Services;
using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

// PostgreSQL
// var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
// builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// SqlServer
// var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection"); // get the connection string from appsettings.json

// From environment variables
var server = builder.Configuration["server"];
var port = builder.Configuration["port"];
var database = builder.Configuration["database"];
var user = builder.Configuration["user"];
var password = builder.Configuration["password"];

var connectionString =
    $"Server={server},{port};Database={database};User Id={user};Password={password};TrustServerCertificate=True;";

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Injecting MediatR to DI
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

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

await app.MigrateDbAsync();

app.Run();
