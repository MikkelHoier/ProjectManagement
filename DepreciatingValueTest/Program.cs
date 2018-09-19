using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciatingValueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Asset asset1 = new Asset(5000000.0m);
            Asset asset2 = new Asset(6000000.0m);
            Asset asset3 = new Asset(7000000.0m);


            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Current values:\n" +
                $"Asset 1: {asset1.ValueOfAsset:c}\n" +
                $"Asset 2: {asset2.ValueOfAsset:c}\n" +
                $"Asset 3: {asset3.ValueOfAsset:c}\n");

                asset1.CalculateAnnualDepreciationRate();
                asset2.CalculateAnnualDepreciationRate();
                asset3.CalculateAnnualDepreciationRate();
            }
            Console.ReadLine();
        }    
        
    }
}
