using CarReservation.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.DataAccess
{
    /// <summary>
    /// Class designed to work sql data from CarReservation DB related to Employees. Inheritance from Repository.
    /// </summary>
    public class EmployeeRepository : Repository
    {
        /// <summary>
        /// Returns a list of all Employees and their properties from the Employees table in CarReservationDB
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>(0);
            string query = "SELECT * FROM Employees";
            DataSet dataSet = Execute(query);
            DataTable dataTable = dataSet.Tables[0];
            foreach(DataRow row in dataTable.Rows)
            {
                Employee employee = new Employee((string)row["FirstName"],
                    (int)row["EmployeeId"],
                    (string)row["Initials"],
                    (string)row["LastName"],
                    (string)row["PhoneNumber"]);
                employees.Add(employee);
            }
            return employees;
        }
    }
}
