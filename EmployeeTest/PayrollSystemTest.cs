﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest
{
    class PayrollSystemTest
    {
        static void Main(string[] args)
        {
            SalariedEmployee salariedEmmployee = new SalariedEmployee("John", "smith", "111-11-1111", 800.00M);
            HourlyEmployee hourlyEmployee = new HourlyEmployee("karen", "Price", "222-22-222", 16.75M, 40.0M);
            CommissionEmployee commissionEmployee = new CommissionEmployee("Sue", "jones", "333-33-3333", 10000.00M, 0.06M);
            BasePlusCommissionEmployee basePlusCommissionEmployee = new BasePlusCommissionEmployee("Bob", "Lewis", "444-44-4444", 5000.00M, .04M, 300.00M);

            Console.WriteLine("Employes processed individually:\n");

            Console.WriteLine($"{salariedEmmployee}\n" +
                $"earned: {salariedEmmployee.Earnings():C}\n");
            Console.WriteLine($"{hourlyEmployee}\n" +
                $"earned: {hourlyEmployee.Earnings():C}\n");
            Console.WriteLine($"{commissionEmployee}\n" +
                $"earned: {commissionEmployee.Earnings():C}\n");
            Console.WriteLine($"{basePlusCommissionEmployee}\n" +
                $"earned: {basePlusCommissionEmployee.Earnings():C}\n");

            var employees = new List<Employee>() { salariedEmmployee, hourlyEmployee, commissionEmployee, basePlusCommissionEmployee };
            
            foreach (var currentEmployee in employees)
            {
                Console.WriteLine(currentEmployee);

                if (currentEmployee is BasePlusCommissionEmployee)
                {
                    BasePlusCommissionEmployee employee = (BasePlusCommissionEmployee)currentEmployee;

                    employee.BaseSalary *= 1.10M;

                    Console.WriteLine($"new base salary with 10% increase is: {employee.BaseSalary:C}");
                }

                Console.WriteLine($"earned: {currentEmployee.Earnings():C}\n");

                
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"Employee {i} is a {employees[i].GetType()}");
            }

            Console.ReadLine();
        }
    }
}
