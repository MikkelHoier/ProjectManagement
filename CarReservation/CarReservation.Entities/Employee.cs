using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Entities
{
    public class Employee
    {
        #region Fields
        private string emailDomain = "@ssa-nordjylland.dk";
        private string firstName;
        private int id;
        private string initials;
        private string lastName;
        private string phoneNumber;
        #endregion


        #region Constructers
        public Employee(string firstName, int id, string initials, string lastName, string phoneNumber)
        {            
            FirstName = firstName;
            Id = id;
            Initials = initials;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        #endregion


        #region Properties        
        public string EmailDomain
        {
            get
            {
                return emailDomain;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                foreach(char c in value)
                {
                    if (Char.IsLetter(c))
                    {
                        firstName = value;
                    }
                    else
                    {
                        throw new ArgumentException("fornavn kan kun indholde bogstaver");
                    }
                }
            }
        }
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Initials
        {
            get
            {
                return initials;
            }
            set
            {
                foreach(char c in value)
                {
                    if (Char.IsLetter(c))
                    {
                        initials = value;
                    }
                    else
                    {
                        throw new ArgumentException("Intialer kan kun indholde bogstaver.");
                    }
                }
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
                foreach(char c in value)
                {
                    if (Char.IsLetter(c))
                    {
                        lastName = value;
                    }
                    else
                    {
                        throw new ArgumentException("Efternavn kan kun indholde bogstaver");
                    }
                }                
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        #endregion


    }
}
