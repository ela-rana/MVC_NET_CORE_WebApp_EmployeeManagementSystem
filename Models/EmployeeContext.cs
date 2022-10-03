using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    //class representing our database
    public class EmployeeContext:DbContext
    {
        //constructor
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        //represents our employee table
        public DbSet<Employee> Employees { get; set; }

        //represents our department table
        public DbSet<Department> Departments { get; set; }

        //data seeding (creating dummy records for database)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { DeptId = 1, DeptName = "Human Resources" },
                new Department { DeptId = 2, DeptName = "Finance" },
                new Department { DeptId = 3, DeptName = "Informational Technology" },
                new Department { DeptId = 4, DeptName = "Marketing" },
                new Department { DeptId = 5, DeptName = "Operations" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, DeptId=1, Age = 33, Address = "CA", Department = Dept.HumanResources, Name = "Elena", ImageName = "elena.jpg", Salary = 5000 },
                new Employee() { Id = 102, DeptId=3, Age = 45, Address = "MO", Department = Dept.InformationTechnology, Name = "Logan", ImageName = "logan.jpg", Salary = 4000 },
                new Employee() { Id = 103, DeptId=2, Age = 42, Address = "MS", Department = Dept.Finance, Name = "Michael", ImageName = "michael.jpg", Salary = 5000 },
                new Employee() { Id = 104, DeptId=4, Age = 23, Address = "AL", Department = Dept.Marketing, Name = "Nathan", ImageName = "nathan.jpg", Salary = 3000 }
                );
        }
    }
}
