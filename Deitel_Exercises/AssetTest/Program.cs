using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Asset asset = new Asset("Something", 100, 50);

            Console.WriteLine($"Name: {asset.AssetName}\nValue: {asset.AssetValue}\nDeprication: {asset.DepricationValue}");
            Console.ReadLine();
            
            asset.AssetValue = asset.AssetValue * 1.05m;
            asset.DepricationValue = asset.DepricationValue * 1.05m;

            Console.WriteLine($"Name: {asset.AssetName}\nValue: {asset.AssetValue}\nDeprication: {asset.DepricationValue}");
            Console.ReadLine();
        }
    }
}
