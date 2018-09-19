using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest
{
    class Square : TwoDimensionalShape
    {
        private double length;        

        public Square(double length)
        {
            Length = length;            
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        

        public override double Area => Length * Length;
    }
}
