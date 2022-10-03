using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public class DBCRUDRepository : ICRUD
    {
        private EmployeeContext _employeeContext;

        public DBCRUDRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public void AddRecord(Employee employee)
        {
            //to set DeptID based on department name (from Dept enum)
            switch (employee.Department.ToString())
            {
                case "HumanResources":
                    employee.DeptId = 1;
                    break;
                case "Finance":
                    employee.DeptId = 2;
                    break;
                case "InformationTechnology":
                    employee.DeptId = 3;
                    break;
                case "Marketing":
                    employee.DeptId = 4;
                    break;
                case "Operations":
                    employee.DeptId = 5;
                    break;
            }
            _employeeContext.Add(employee); //add the passed new employee record to our database representing context
            _employeeContext.SaveChanges(); //save this add change to the database
        }

        public void DeleteRecord(int? id)
        {
            Employee e = _employeeContext.Employees.Find(id); //finds the record we want to delete (the one with the passed id)
            if(e != null)
            {
                _employeeContext.Employees.Remove(e); //deletes the record with the passed id from our database representing context
                _employeeContext.SaveChanges(); //saves this deletion to the database
            }
        }

        public List<Employee> GetAllRecords()
        {
            return _employeeContext.Employees.ToList<Employee>();
        }

        public Employee? GetRecord(int? id)
        {
            return _employeeContext.Employees.Find(id);
        }

        public int MaxID()
        {
            return _employeeContext.Employees.Max(x=>x.Id);
        }

        public void UpdateRecord(Employee employee)
        {
            Employee e = _employeeContext.Employees.Find(employee.Id); //finds the record we want to update (the one with the passed id)
            if (e != null)
            {
                e.Id = employee.Id;
                e.Name = employee.Name;
                e.Age = employee.Age;
                e.Address = employee.Address;
                e.Salary = employee.Salary;
                e.Department = employee.Department;
                e.ImageName = employee.ImageName;

                //to set DeptID based on department name (from Dept enum)
                switch (e.Department.ToString())
                {
                    case "HumanResources":
                        e.DeptId = 1;
                        break;
                    case "Finance":
                        e.DeptId = 2;
                        break;
                    case "InformationTechnology":
                        e.DeptId = 3;
                        break;
                    case "Marketing":
                        e.DeptId = 4;
                        break;
                    case "Operations":
                        e.DeptId = 5;
                        break;
                }
                _employeeContext.SaveChanges(); //save this update to the database

            }

        }
    }
}
