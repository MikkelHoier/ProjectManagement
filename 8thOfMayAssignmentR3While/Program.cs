using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8thOfMayAssignmentR3While
{
    class Program
    {
        static void Main(string[] args)
        //The methods repressent each part of the assignment. Make a method call to see my solution
        {
            //PartOne();
            //PartTwo();
            //PartThree();
            PartFour();
        }

        static void PartOne()
        {
            int input;
            try
            {
                Console.WriteLine("Type in a positive number");
                input = Convert.ToInt32(Console.ReadLine());
                if (input < 0)
                {
                    Console.WriteLine("Please input a positive number");
                    PartOne();
                }

                for(int i = 0; i <= input; i++)
                {
                    Console.WriteLine(i);
                }
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error: please only use numbers");
                PartOne();
            }
        }

        static void PartTwo()
        {
            List<int> numbers = new List<int>();
            int input = 1;            
            Console.WriteLine("Type in a row of numbers you would like to add. Calculation while start when you enter the number 0");
            try
            {
                while(input != 0)
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    numbers.Add(input);
                }
                Console.WriteLine(numbers.Sum());
                Console.WriteLine("Goodbye");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error: The Program Will Now Reset");
                PartTwo();
            }
        }

        static void PartThree()
        {
            int input;
            int staticInput;
            Console.WriteLine("Indtast et tal du gerne vil have en tabel af");
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                staticInput = input;
                for(int i = 1; i <= 9; i++)
                {                    
                    input = input + staticInput;
                    Console.WriteLine(input);
                }
                Console.WriteLine("Goodbye");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error : The Input has to be a whole number : The Program Will Now Reset");
                PartThree();
            }
        }

        static void PartFour()
        {

        }
    }
}
