using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystemTest
{
    class SalariedEmployee : Employee
    {
        #region Variables
        private decimal weeklySalary;
        #endregion


        #region Constructor
        public SalariedEmployee(string firstName, string lastName, string socialSercurityNumber, Date birthdate, decimal weeklySalary)
            : base(firstName, lastName, socialSercurityNumber, birthdate)
        {
            WeeklySalary = weeklySalary;
        }
        #endregion


        #region Property
        public decimal WeeklySalary
        {
            get
            {
                return weeklySalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(WeeklySalary)} must be >= 0");
                }

                weeklySalary = value;
            }
        }
        #endregion


        #region Methods
        public override decimal Earnings()
        {
            return WeeklySalary;
        }

        public override string ToString()
        {
            return $"salaried employee: {base.ToString()}\n" +
                $"weekly salary: {WeeklySalary:C}";
        }

        public override void BirthdayBonus()
        {
            WeeklySalary = weeklySalary + 100;
        }
        #endregion
    }
}
