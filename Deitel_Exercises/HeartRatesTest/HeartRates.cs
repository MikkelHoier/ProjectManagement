using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartRatesTest
{
    class HeartRates
    {
        private string firstName;
        private string lastName;
        private int birthYear;
        readonly private int currentYear = DateTime.Now.Year;
        
        public HeartRates(string firstName, string lastName, int birthYear)
        {
            Firstname = firstName;
            LastName = lastName;
            BirthYear = birthYear;
        }

        #region Properties
        public string Firstname
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;

            }
        }
        public int BirthYear
        {
            get
            {
                return birthYear;
            }
            set
            {
                if (value > 1900)
                {
                    birthYear = value;
                }
            }
        } 
        #endregion

        public int AgeInYears()
        {
            int age = currentYear - birthYear;
            return age;
        }

        public decimal MaximumHeartRate()
        {
            decimal maximumHeartRate = 220 - AgeInYears();
            return maximumHeartRate;
        }

        public decimal TargetHeartRateLowest()
        {
            decimal targetHeartRateLowest = MaximumHeartRate() * 0.50m;
            return targetHeartRateLowest;
        }
    }
}
