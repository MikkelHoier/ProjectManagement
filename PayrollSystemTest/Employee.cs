using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystemTest
{
    public abstract class Employee
    {
        #region Variables/Properties
        public string FirstName { get; }
        public string Lastname { get; }
        public string SocialSercurityNumber { get; }
        public Date BirthDate { get; }
        #endregion


        #region Constructor
        public Employee(string firstName, string lastName, string socialSercurityNumber, Date birthDate)
        {
            FirstName = firstName;
            Lastname = lastName;
            SocialSercurityNumber = socialSercurityNumber;
            BirthDate = birthDate;
        }
        #endregion


        #region Methods
        public override string ToString()
        {
            return $"{FirstName} {Lastname}\n" +
                $"social sercurity number: {SocialSercurityNumber}";
        }

        public abstract decimal Earnings();

        public abstract void BirthdayBonus();
        #endregion
    }
}
