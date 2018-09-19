using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTest
{
    class Program
    {
        static void Main(string[] args)
        {                       
            Date date = new Date(12,30,2018);

            Console.WriteLine($"{date.Day}/{date.Month}-{date.Year}");
            Console.ReadLine();

            date.NextDay();

            Console.WriteLine($"{date.Day}/{date.Month}-{date.Year}");
            Console.ReadLine();


            date.NextDay();

            Console.WriteLine($"{date.Day}/{date.Month}-{date.Year}");
            Console.ReadLine();


            date.NextDay();

            Console.WriteLine($"{date.Day}/{date.Month}-{date.Year}");
            Console.ReadLine();
        }
    }
}
