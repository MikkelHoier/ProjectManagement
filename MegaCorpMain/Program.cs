using MegaCorp.DataAccess;
using MegaCorp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorpMain
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();

            List<Employee> employees = employeeRepo.GetAllEmployees();

            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

            Console.ReadLine();
        }
    }
}
