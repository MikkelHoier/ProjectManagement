using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8thOfMayAssignment2
{
    class Program
    {
        static void Main()
        {
            //PartOne();
            //PartTwo();
            //PartThree();
            //PartFour();
        }

        static void PartOne()
        {
            int number = 1;

            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            while (number <= 10)
            {
                Console.WriteLine(number);
                number++;
            }
            Console.ReadLine();
        }

        static void PartTwo()
        {
            Random rnd = new Random();
            int tal = 0;
            while(tal != 6)
            {
                tal = rnd.Next(1, 7);
                Console.WriteLine(tal);
            }
            Console.ReadLine();
        }

        static void PartThree()
        {
            int number = 1;
            for ( int i = 1; i < 25; i++)
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine();

            while(number < 25)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine(number);
                }
                number++;
            }
            Console.ReadLine();
        }

        static void PartFour()
        {
            for(int i = 0; i < 25; i++)
            {
                if(i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
    }
}
