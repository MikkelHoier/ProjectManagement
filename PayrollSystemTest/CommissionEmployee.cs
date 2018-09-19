using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystemTest
{
    class CommissionEmployee : Employee
    {
        #region Variables
        private decimal grossSales;
        private decimal commissionRate;
        #endregion

        #region Constructor
        public CommissionEmployee(string firstName, string lastName, string socialSercurityNumber, Date birthDate, decimal grossSales, decimal commisionrate)
            : base(firstName, lastName, socialSercurityNumber, birthDate)
        {
            GrossSales = grossSales;
            CommissionRate = commissionRate;
        }
        #endregion


        #region Properties
        public decimal GrossSales
        {
            get
            {
                return grossSales;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(GrossSales)} must be >=0");
                }
                grossSales = value;
            }
        }

        public decimal CommissionRate
        {
            get
            {
                return commissionRate;
            }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(CommissionRate)} must be > 0 and <1");
                }
                commissionRate = value;
            }

        }
        #endregion

        #region Methods
        public override decimal Earnings()
        {
            return CommissionRate * GrossSales;
        }

        public override string ToString()
        {
            return $"commission emplyee: {base.ToString()}\n" +
                $"gross sales: {GrossSales:C}\n" +
                $"commission rate: {CommissionRate:F2}";
        }

        public override void BirthdayBonus()
        {
           GrossSales = GrossSales + 100;
        }
        #endregion
    }
}
