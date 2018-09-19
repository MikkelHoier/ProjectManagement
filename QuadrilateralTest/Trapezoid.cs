using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrilateralTest
{
    class Trapezoid:Quadrilateral
    {
        public Trapezoid(double x1, double x2, double y1, double y2, double h)
            : base(x1, x2, y1, y2, h)
        {

        }

        public double CalculateCircumference(double x, double y)
        {
            return X1 + X2 + Y1 + Y2;
        }

        public double CalculateArea()
        {
            return 0.5 * (Y1 + Y2) * H;
        }
    }
}
