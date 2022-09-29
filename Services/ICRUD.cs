using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    /// <summary>
    /// Defines all types of actions that can be performed on Employee 
    /// Records within the database, including CRUD- create, read, update, delete
    /// </summary>
    public interface ICRUD
    {
        /// <summary>
        /// Adds the passed record object to the database
        /// </summary>
        /// <param name="employee">record to be added</param>
        void AddRecord(Employee employee);

        /// <summary>
        /// Retrieves the record for the passed id
        /// </summary>
        /// <param name="id">id of the record to be retrieved</param>
        /// <returns>the record that matches passed id or null if the id is not found in database</returns>
        Employee? GetRecord(int? id);

        /// <summary>
        /// updates the passed record
        /// </summary>
        /// <param name="employee">the record with its fields updated</param>
        void UpdateRecord(Employee employee);

        /// <summary>
        /// deletes the record that has the passed id
        /// </summary>
        /// <param name="id">the id of the record to be deleted</param>
        void DeleteRecord(int? id);

        /// <summary>
        /// to get the highest id value in the database
        /// </summary>
        /// <returns>highest id value</returns>
        int MaxID();

        /// <summary>
        /// to get all Employee records from the database
        /// </summary>
        /// <returns>a list of all employees in the database</returns>
        List<Employee> GetAllRecords();

    }
}
