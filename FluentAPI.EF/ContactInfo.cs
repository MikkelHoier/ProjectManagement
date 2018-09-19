namespace FluentAPI.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactInfos")]
    public partial class ContactInfo : BaseClass
    {

        protected string phone;
        #region Constructors
        public ContactInfo(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }

        public ContactInfo() { } 
        #endregion

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Id { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(25)]
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                foreach (char c in value)
                {
                    if (char.IsLetter(c))
                    {
                        throw new Exception(nameof(value));
                    }
                }
                phone = value;
            }
        }

        public virtual Employee Employee { get; set; }
    }
}
