using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EF
{
    public class Person:BaseClass
    {
        private string firstName;
        private string lastName;
        
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (!Validator.NameIsValid(value))
                {
                    throw new Exception(nameof(value)); 
                }
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
                if (!Validator.NameIsValid(value))
                {
                    throw new Exception(nameof(value));
                }
                lastName = value;
            }
        }
    }
}
