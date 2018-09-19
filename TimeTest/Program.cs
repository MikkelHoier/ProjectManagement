using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Time3();
            var t2 = new Time3(2);
            var t3 = new Time3(21, 34);
            var t4 = new Time3(12, 25, 42);
            var t5 = new Time3(t4);

            //Console.WriteLine("Constructed with:\n");
            //Console.WriteLine("tl: all arguments defaulted");
            //Console.WriteLine($"    {t3.ToUniversalString()}");

            Console.ReadLine();
        }
    }
}
