using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikkelHøjerJensen.DataApp.Entities
{
    //Class to represent a person
    public class Person
    {
        #region Fields
        private int personId;
        private ContactInfomation contactInfomation;
        private string firstName;
        private string lastName;
        private string socialSecurityNumber;

        #endregion


        #region Properties
        public int PersonId
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
            }
        }
        public ContactInfomation ContactInfomation
        {
            get
            {
                return contactInfomation;
            }
            set
            {
                contactInfomation = value;
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
                    if (char.IsLetter(c))
                    {
                        firstName = value;
                    }
                    else
                    {
                        throw new Exception("MÅ KUN INHOLDE BOGSTAVER");
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
                lastName = value;
            }
        }
        public string SocialSecurityNumber
        {
            get => socialSecurityNumber;
            set => socialSecurityNumber = value;

        }
        #endregion

        #region Constructors
        public Person(ContactInfomation contactInfomation, string firstName, string lastName, string socialSecurityNumber)
        {            
            ContactInfomation = contactInfomation;
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
          
        }

        public Person(int personId, ContactInfomation contactInfomation, string firstName, string lastName, string socialSecurityNumber)
            :this(contactInfomation,firstName,lastName,socialSecurityNumber)
        {
            PersonId = personId;
            ContactInfomation = contactInfomation;
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;

        }
        #endregion

        #region Methods

        #endregion
    }
}
