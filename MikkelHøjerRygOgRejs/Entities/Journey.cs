using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Journey
    {
        #region Fields
        private int adults;
        private int children;
        private PriceDetails currentPriceDetails;
        private DateTime departureDate;
        private Destination destination;
        private bool isFirstClass;
        private decimal luggageAmount;
        #endregion


        #region Constructers
        public Journey(int adults, int children, DateTime departureDate, Destination destination, bool isFirstClass, decimal luggageAmount)
        {
            Adults = adults;
            Children = children;
            DepartureDate = departureDate;
            Destination = destination;
            IsFirstClass = isFirstClass;
            LuggageAmount = luggageAmount;           
        }       
        #endregion


        #region Properties
        public int Adults { get => adults; set => adults = value; }
        public int Children { get => children; set => children = value; }
        public DateTime DepartureDate { get => departureDate; set => departureDate = value; }
        public Destination Destination { get => destination; set => destination = value; }
        public bool IsFirstClass { get => isFirstClass; set => isFirstClass = value; }
        public decimal LuggageAmount { get => luggageAmount; set => luggageAmount = value; }
        internal PriceDetails CurrentPriceDetails { get => currentPriceDetails; set => currentPriceDetails = value; } 
        #endregion
    }
}
