using MegaCorp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorp.DataAccess
{
    public class EmployeeRepo : BaseRepo
    {
        public EmployeeRepo()
            :base(ConnectionsStrings.MegaCorpConnection)
        {

        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            string sqlQuery = "SELECT * FROM Employees";
            DataSet employeeSet = base.Execute(sqlQuery);
            DataTable employeeTable = employeeSet.Tables[0];

            foreach(DataRow row in employeeTable.Rows)
            {
                Employee employee = Convert.ConvertToEmployee(row);
                employees.Add(employee);
            }
            return employees;
        }
    }
}
