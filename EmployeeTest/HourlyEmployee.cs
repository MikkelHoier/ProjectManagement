using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest
{
    class HourlyEmployee : Employee
    {
        #region Variables
        private decimal wage;
        private decimal hours;
        #endregion


        #region Constructor
        public HourlyEmployee(string firstName, string lastName, string socialSercurityNumber, decimal hourlyWage, decimal hoursWorked)
            : base(firstName, lastName, socialSercurityNumber)
        {
            Wage = hourlyWage;
            Hours = hoursWorked;
        }
        #endregion


        #region Properties
        public decimal Wage
        {
            get
            {
                return wage;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Wage)} must be >=0");
                }
                wage = value;
            }
        }

        public decimal Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (value < 0 || value > 168)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Hours)} must be >=0 and <=168");
                }
                hours = value;
            }
        }
        #endregion


        #region Method
        public override decimal Earnings()
        {
            {
                if (Hours <= 40)
                {
                    return Wage * Hours;
                }
                else
                {
                    return (40 * Wage) + ((Hours - 40) * Wage * 1.5M);
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"hourly employee: {base.ToString()}\n" +
                $"hourly wage: {Wage:C}\n" +
                $"hours worked: {Hours:F2}";
        }
        #endregion        
    }
}
