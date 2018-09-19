using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MikkelHøjerJensen.DataApp.Entities
{
    //class to represent a ContactInfomation
    public class ContactInfomation
    {
        #region Fields
        private int id;
        private string mail;
        private string phoneNumber;
        private string homePage;
        #endregion


        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {               
                mail = value;                             
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

        public string HomePage
        {
            get
            {
                return homePage;
            }
            set
            {
                if (Regex.IsMatch(value, @"^www\.|WWW\."))
                {
                    homePage = value;
                }
                else
                {
                    throw new Exception("SKAL STARTE MED WWW");
                }                
            }
        }
        #endregion

        #region Constructers
        public ContactInfomation(string mail, string phoneNumber, string homePage)
        {
            Mail = mail;
            PhoneNumber = phoneNumber;
            HomePage = homePage;
        }

        public ContactInfomation(int id, string mail, string phoneNumber, string homePage)
            :   this(mail, phoneNumber, homePage)
        {
            Id = id;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"ID: {Id}\nMail: {Mail}\n{phoneNumber}\nPhone Number: {PhoneNumber}\nHomepage{HomePage}";
        }
        #endregion
    }
}
