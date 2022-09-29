using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace EmployeeManagementSystem.Models
{
    //enumerates all work departments in the organization
    public enum Dept
    {
        HumanResources = 1,
        Finance,
        InformationTechnology,
        Marketing,
        Operations,
        Logistics,
        Executive
    }
    public class Employee
    {
        [Display(Name="Employee ID")]
        [Required(ErrorMessage = "ID is a required field")]
        public int Id { get; set; }

        [Display(Name = "Employee Full Name")]
        [Required(ErrorMessage = "Name is a required field")]
        [MaxLength(100, ErrorMessage ="Name too long, can be upto 100 characters max")]
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
