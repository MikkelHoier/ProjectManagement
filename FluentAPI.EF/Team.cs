namespace FluentAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Team : BaseClass
    {
        protected string name;
        protected DateTime? startDate;
        protected DateTime? endDate;

        #region Constructors        
        public Team(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Team()
        {
            Employees = new HashSet<Employee>();
        }
        #endregion

        #region Properties
        [StringLength(50)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int? ProjectId { get; set; }

        public string Description { get; set; }

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

        public DateTime? EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (!Validator.DateIsValid(value))
                {
                    throw new Exception(nameof(value));
                }
                endDate = value;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual Project Project { get; set; } 
        #endregion
    }
}
