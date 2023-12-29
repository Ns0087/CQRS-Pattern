using AutoMapper;
using CQRS_Pattern.AutoMapperProfile;
using CQRS_Pattern.Commands.Implementations;
using CQRS_Pattern.Commands.Interfaces;
using CQRS_Pattern.DAL.DBContext;
using CQRS_Pattern.DAL.Repositories.Implementations;
using CQRS_Pattern.DAL.Repositories.Interfaces;
using CQRS_Pattern.Queries.Implementations;
using CQRS_Pattern.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();


// Add services to the container.
builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeCS")));

//Add Respository
builder.Services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();
builder.Services.AddScoped<IEmployeeCommandsRepository, EmployeeCommandsRepository>();

//Add Services
builder.Services.AddTransient<IEmployeeQueries, EmployeeQueries>();
builder.Services.AddTransient<IEmployeeCommands, EmployeeCommands>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
