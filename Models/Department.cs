using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    //master table
    public class Department
    {
        [Key] //primary key in table
        public int DeptId { get; set; }
        public string? DeptName { get; set; }

        //1 to many relation (1 dept can have multiple employees)
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
