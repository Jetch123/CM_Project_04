using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> coeeficient = new List<int>() { 1, 2, 3, -4 };
            double[] boundaries = new double[2] { 0, 3 };

            Integration form = new CalcIntegral(coeeficient);
            form.Display();

            Console.WriteLine(form.Trapezoidal(boundaries, 2));
            Console.WriteLine(form.Simpson(boundaries, 2));

        }
    }
}
