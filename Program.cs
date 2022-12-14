using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton<ICRUD, CRUD>();    //to register employee CRUD actions service
builder.Services.AddScoped<ICRUD, DBCRUDRepository>();    //to register DB connecting entity core
//builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlite(
//    "Data Source= EmployeesDB.db"));
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(
    "Server=ELAPC;Database=EMS;Trusted_Connection=true;MultipleActiveResultSets=True"));
builder.Services.AddSingleton<IFormatNumber, FormatClass>();    //to register FormatNumber service
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeContext>();
    dbContext.Database.EnsureCreated(); //creates the database if it doesn't already exist
    //use context
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/*
Steps to building Employee Management System

1. Create Employee model (Employee.cs)
2. Create Service Interface (ICRUD.cs)
3. Add class to implement interface (CRUD.cs)
4. Register service (Program.cs --> builder.Services.AddSingleton<ICRUD,CRUD>();
5. Add Employee to navigation bar (_Layout.cshtml -->  
   <a class="nav-link text-dark" asp-area="" asp-controller="Employee" asp-action="Index">Employees</a>)
6. Add EmployeeController.cs in your Controllers folder
7. Add Employee folder in your Views folder
8. Inject CRUD service (EmployeeController.cs --> public EmployeeController(ICRUD crud){this.crud = crud;})
9. Create IndexViewModel class in Models folder (IndexViewModel.cs)
   Write indexmodel and logic in index method in EmployeeController
10. Add Index.cshtml view (list type) in Employee folder. Update html to display employees.
11. Add Details action (When you click Details for each employee, what to do)
*/