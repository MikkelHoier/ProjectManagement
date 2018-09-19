using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square(5,5,5,5);
            Rectangle rectangle = new Rectangle(5, 5, 10, 10);
            Trapezoid trapezoid = new Trapezoid(10, 10, 15, 5 , 8);
            Parallelogram parallelogram = new Parallelogram(8, 8, 4, 4, 6);

            Console.WriteLine(square.CalculateArea());
            Console.WriteLine(square.CalculateCircumference());

            Console.ReadLine();
        }
    }
}
