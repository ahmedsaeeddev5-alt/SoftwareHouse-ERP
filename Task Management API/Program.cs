using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task_Management_API.Data;
using Task_Management_API.Data.Models;
using Task_Management_API.Extension;
using Task_Management_API.Repositories;
using Task_Management_API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Myconnection")));
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddScoped<ITaskRepository,TaskRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<
    IDepartmentRepository,
    DepartmentRepository>();
builder.Services.AddScoped<
    IEmployeeRepository,
    EmployeeRepository>();
builder.Services.AddScoped<
    IProjectRepository,
    ProjectRepository>();
builder.Services.AddScoped<
    IProjectMemberRepository,
    ProjectMemberRepository>();
builder.Services.AddScoped<
    IMilestoneRepository,
    MilestoneRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenJwtAuth();
builder.Services.AddCustomJwtAuth(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
