using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciatingValueTest
{
    class Asset
    {
        static decimal annualDepreciationRate = 0.11m;
        private decimal valueOfAsset;

        public Asset(decimal value)
        {
            ValueOfAsset = value;            
        }

        static public decimal AnnualDepreciationRate
        {
            get
            {
                return annualDepreciationRate;
            }            
        }
        public decimal ValueOfAsset
        {
            get;
            set;
        }

        public void CalculateAnnualDepreciationRate()
        {
            decimal depreciation = ValueOfAsset * annualDepreciationRate;
            ValueOfAsset = ValueOfAsset - depreciation;
        }
    }
}
