namespace FluentAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project : BaseClass
    {
        #region Field
        private string name;
        private decimal? budget;
        #endregion


        #region Constructor
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Teams = new HashSet<Team>();
        } 

        public Project(string name, decimal budget, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Budget = budget;
            StartDate = startDate;
            EndDate = endDate;
        }
        #endregion
               
        [StringLength(50)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception(nameof(value));
                }
                name = value;
            }
        }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Budget {
            get
            {
                return budget;
            }
            set
            {
                if(value <0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }                
                else
                {
                    budget = value;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
