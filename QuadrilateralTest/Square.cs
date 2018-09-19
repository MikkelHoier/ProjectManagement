using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralTest
{
    class Square:Quadrilateral
    {
        public Square(double x1, double x2, double y1, double y2)
            : base(x1, x2, y1, y2)
        {
            
        } 

        public double CalculateCircumference()
        {
            return X1 + X2 + Y1 + Y2; 
        }

        public double CalculateArea()
        {
            return X1 * Y1;
        }
    }
}
