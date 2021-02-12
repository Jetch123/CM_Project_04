using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    class CalcIntegral : Integration
    {
        public List<int> polynomialCoef { get; set; }
        private int functionSize;


        public CalcIntegral(List<int> newPolynomialCoeffients)
        {
            polynomialCoef = newPolynomialCoeffients;
            functionSize = polynomialCoef.Count;
        }

        public void Display()
        {
            int exponent = polynomialCoef.Count - 1;

            string Fx = $"f(x) = {polynomialCoef[0]}x^{exponent}";
            exponent--;
            for (int i = 1; i < functionSize - 1; i++)
            {
                int coeff = polynomialCoef[i];
                if (coeff > 0)
                    Fx += $" + {coeff}x^{exponent}";
                else
                    Fx += $" - {Math.Abs(coeff)}x^{exponent}";

                exponent--;
            }
            int poly = polynomialCoef[functionSize - 1];
            if (poly > 0)
                Fx += $" + {poly}";
            else
                Fx += $" - {Math.Abs(poly)}";

            Console.WriteLine(Fx);
        }

        private double GetFunctionValue(double n)
        {
            int exponent = polynomialCoef.Count - 1;
            double result = 0;
            for (int i = 0; i < functionSize; i++)
            {
                result += polynomialCoef[i] * Math.Pow(n, exponent);
                exponent--;
            }
            return result;
        }

        public double Trapezoidal(double[] boundaries, int numberOfInterval)
        {
            double h = (boundaries[1] - boundaries[0]) / numberOfInterval;
            double I = GetFunctionValue(boundaries[0]) + GetFunctionValue(boundaries[1]);

            for (int i = 1; i < numberOfInterval - 1; i++)
            {
                I += 2 * GetFunctionValue(boundaries[0] + i * h);
            }
            return (h * I) / 2;
        }

        public double Simpson(double[] boundaries, int numberOfInterval)
        {
            double h = (boundaries[1] - boundaries[0]) / numberOfInterval;
            double I = GetFunctionValue(boundaries[0]) + GetFunctionValue(boundaries[1]);
            for (int i = 1; i < numberOfInterval; i++)
            {
                int coefficient = (i % 2 == 0) ? 2 : 4;
                I += coefficient * GetFunctionValue(boundaries[0] + i * h);
            }
            return (h * I) / 3;

        }
    }
}
