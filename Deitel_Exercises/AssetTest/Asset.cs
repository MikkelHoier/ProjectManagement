using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTest
{
    class Asset
    {
        private string assetName;
        private decimal assetValue;
        private decimal depricationValue;

        public Asset(string assetName, decimal assetValue, decimal depricationValue)
        {
            AssetName = assetName;
            AssetValue = assetValue;
            DepricationValue = depricationValue;
        }

        public string AssetName { get => assetName; set => assetName = value; }
        public decimal AssetValue
        {
            get
            {
                return assetValue;
            }
            set
            {
                if(value > 0.0m)
                {
                    assetValue = value;
                }
            }
        }
        public decimal DepricationValue
        {
            get
            {
                return depricationValue;
            }
            set
            {
                if (value > 0.0m)
                {
                    depricationValue = value;
                }
            }
        }
    }
}
