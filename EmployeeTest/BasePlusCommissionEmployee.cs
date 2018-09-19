using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest
{
    class BasePlusCommissionEmployee : CommissionEmployee
    {
        #region Variable
        private decimal baseSalary; 
        #endregion


        #region Constructor
        public BasePlusCommissionEmployee(string firstName, string lastName, string socialSecurityNumber, decimal grossSales, decimal commissionRate, decimal baseSalery)
            : base(firstName, lastName, socialSecurityNumber, grossSales, commissionRate)
        {
            BaseSalary = baseSalery;
        }
        #endregion


        #region Property
        public decimal BaseSalary
        {
            get
            {
                return baseSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(BaseSalary)} must be >= 0");
                }
                baseSalary = value;
            }
        }
        #endregion


        public override decimal Earnings()
        {
            return BaseSalary + base.Earnings();
        }

        public override string ToString()
        {
            return $"base-salaried {base.ToString()}\n" +
                $"base salary: {BaseSalary:C}";
        }
    }
}
