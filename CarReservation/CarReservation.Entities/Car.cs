using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Entities
{
    public class Car
    {
        #region fields
        private int id;
        private bool isAvailable;
        private string licensePlate;
        private string make;
        private string model;
        private int productionYear; 
        #endregion


        #region Constructer
        public Car(string licensePlate, string make, string model, int productionYear)
        {            
            LicensePlate = licensePlate;
            Make = make;
            Model = model;
            ProductionYear = productionYear;
        }

        public Car(int id, bool isAvailable, string licensePlate, string make, string model, int productionYear)
            :   this(licensePlate, make, model, productionYear)
        {
            Id = id;
            IsAvailable = isAvailable;
        }
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

        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }
            set
            {
                isAvailable = value;
            }
        }

        public string LicensePlate
        {
            get
            {
                return licensePlate;
            }
            set
            {
                
                if (value.Length > 7)
                {
                    throw new Exception("Nummerplade kan kun holde 7 karaktere");
                }
                else if (value.Length <= 0)
                {
                    throw new Exception("Nummerplade skal udfyldes");
                }
                else
                {
                    licensePlate = value;
                }                            
            }
        }

        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public int ProductionYear
        {
            get
            {
                return productionYear;
            }
            set
            {
                productionYear = value;
            }
        } 
        #endregion
    }
}
