using FinalProjectRegistration.Core.IServices;
using FinalProjectRegistration.Domain.IRepositories;
using FinalProjectRegistration.Domain.Services;
using FinalProjectRegistration.Infrastructure.Data;
using FinalProjectRegistration.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Dependency inject all necessary classes.
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IGroupService, GroupService>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();

builder.Services.AddScoped<IDbSeeder, DbSeeder>();

builder.Services.AddDbContext<MainDbContext>(opt =>
{
    opt.UseSqlite($"Data Source=Database.db");
});

builder.Services.AddCors(opt => opt.AddPolicy("anywhere-policy", policy =>
{
    policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Build an instance of the ServiceProvider to gain access to the different dependency injected classes.
var builtService = builder.Services.BuildServiceProvider();
var dbSeeder = builtService.GetService<IDbSeeder>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    dbSeeder.SeedDevelopment();
}
else dbSeeder.SeedProduction();

app.UseCors("anywhere-policy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
