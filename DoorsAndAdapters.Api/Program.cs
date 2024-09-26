using DoorsAndAdapters.Application.Repositories;
using DoorsAndAdapters.Application.Service;
using DoorsAndAdapters.Application.UseCases;
using DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Context;
using DoorsAndAdapters.Infrastructure.EntityFrameworkDataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{ });

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IGlucometerUseCase, GlucometerService>();
builder.Services.AddTransient<IMedicationPlanUseCase, MedicationPlanService>();

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
