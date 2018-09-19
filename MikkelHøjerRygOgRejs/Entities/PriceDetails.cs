using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PriceDetails
    {
        #region Fields
        private decimal destinationPrice;
        private decimal firstClassPrice;
        private decimal luggagePrice;
        private double taxRate = 0.25;        
        #endregion
       

        #region Constructers
        public PriceDetails(decimal destinationPrice, decimal firstClassPrice, decimal luggagePrice)
        {
            this.destinationPrice = destinationPrice;
            this.firstClassPrice = firstClassPrice;
            this.luggagePrice = luggagePrice;
        } 
        #endregion
    }
}
