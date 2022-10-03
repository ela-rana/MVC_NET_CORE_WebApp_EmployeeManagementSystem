using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Models
{
    //enumerates all work departments in the organization
    public enum Dept
    {
        HumanResources = 1,
        Finance,
        InformationTechnology,
        Marketing,
        Operations
    }
    public class Employee
    {
        [Display(Name="Employee ID")]
        [Required(ErrorMessage = "ID is a required field")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } //when your column name is Id, entity framework core automatically
                 //identifies it as primary key, so you don't have to specify this as primary key

        public int DeptId { get; set; } //foreign key

        [Display(Name = "Employee First Name")]
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(100, ErrorMessage ="Name too long, can be upto 100 characters max")]
        [AllLetters(ErrorMessage ="Please enter letters only, no commas, dots, spaces allowed")]
        public string? Name { get; set; }

        [Range(18,100,ErrorMessage="Age must be between 18-100")]
        public int Age { get; set; }

        [Display(Name="Mailing Address")]
        [DataType(DataType.MultilineText)]
        [MaxLength (250,ErrorMessage ="Address too long, can be upto 250 characters max")]
        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }

        public Dept Department { get; set; }

        public string? ImageName { get; set; }
    }
}
