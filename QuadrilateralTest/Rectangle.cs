using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralTest
{
    class Rectangle:Quadrilateral
    {
        public Rectangle(double x1, double x2, double y1, double y2)
            : base(x1, x2, y1, y2)
        {
            if(x1 != x2 || y1 != y2)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public double CalculateCircumference(double x, double y)
        {
            return 2 * X1 + 2 * Y1;
        }

        public double CalculateArea()
        {
            return X1 * Y1;
        }
    }
}
