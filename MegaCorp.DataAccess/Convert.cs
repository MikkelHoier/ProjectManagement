using MegaCorp.Entities;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorp.DataAccess
{
    public static class Convert
    {
        public static Employee ConvertToEmployee(DataRow employeeRow)
        {
            Employee employee = new Employee((int)employeeRow["EmployeeId"], (string)employeeRow["Firstname"], (string)employeeRow["LastName"], (string)employeeRow["Position"], (decimal)employeeRow["Salary"], (DateTime)employeeRow["StartDate"]);
            return employee;
        }
    }
}
