using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    /// <summary>
    /// Consists of actions that can be performed on Employee 
    /// Records within the database, including CRUD- create, read, update, delete
    /// </summary>
    public class CRUD : ICRUD
    {
        private List<Employee> employees;

        public CRUD()
        {
            employees = new List<Employee>();
            
            //to add dummy data for our list (which represents the backend database)
            employees.Add(new Employee() { Id = 101, Age = 33, Address = "NJ", Department = Dept.HumanResources, Name = "Elena", ImageName = "elena.jpg", Salary = 5000 });
            employees.Add(new Employee() { Id = 102, Age = 45, Address = "NC", Department = Dept.InformationTechnology, Name = "Logan", ImageName = "logan.jpg", Salary = 4000 });
            employees.Add(new Employee() { Id = 103, Age = 42, Address = "NJ", Department = Dept.Finance, Name = "Michael", ImageName = "michael.jpg", Salary = 5000 });
            employees.Add(new Employee() { Id = 104, Age = 23, Address = "NJ", Department = Dept.Marketing, Name = "Nathan", ImageName = "nathan.jpg", Salary = 3000 });
        }
        public void AddRecord(Employee employee)
        {
            employees.Add(employee);
        }

        public void DeleteRecord(int? id)
        {
            Employee? e = employees.Find(x => x.Id == id);
            if(e!= null)
                employees.Remove(e);
        }

        public List<Employee> GetAllRecords()
        {
            return employees;
        }

        public Employee? GetRecord(int? id)
        {
            if (id == null)
                return null;
            else
                return employees.Find(x => x.Id == id);
        }

        public int MaxID()
        {
            return employees.Max(x => x.Id);
        }

        public void UpdateRecord(Employee employee)
        {
            Employee? e = employees.Find(x => x.Id == employee.Id);
            if(e!= null)
            {
                e.Id = employee.Id;
                e.Name = employee.Name;
                e.Age = employee.Age;
                e.Address = employee.Address;
                e.Salary = employee.Salary;
                e.Department = employee.Department;
                e.ImageName = employee.ImageName;
            }
        }
    }
}
