namespace FluentAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee : Person
    {
        #region Fields
        protected DateTime? birthDate;
        protected DateTime? startDate;
        #endregion
        

        #region Constructors    
        public Employee() { }
        
        public Employee(string firstName, string lastName, string socialSecurityNumber, decimal salary, DateTime birthDate, DateTime startDate)
            : this(firstName, lastName, socialSecurityNumber, salary, birthDate, startDate, null) { }

        public Employee(string firstName, string lastName, string socialSecurityNumber, decimal salary, DateTime birthDate, DateTime startDate, ContactInfo contactInfo)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            Salary = salary;
            BirthDate = birthDate;
            StartDate = startDate;
            ContactInfo = contactInfo;
        }
        #endregion

        #region Properties
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public int? TeamId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salary { get; set; }

        public DateTime? BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                if (!Validator.DateIsValid(value))
                {
                    throw new Exception(nameof(value));
                }
                birthDate = value;
            }
        }

        public DateTime? StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                if (!Validator.DateIsValid(value))
                {
                    throw new Exception(nameof(value));
                }
                startDate = value;
            }
        }

        [StringLength(50)]
        public string SocialSecurityNumber { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }

        public virtual Team Team { get; set; } 
        #endregion
    }
}
