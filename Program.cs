using System;
using System.Linq;
using System.Numerics;
using MathNet.Numerics;
using MathNet.Numerics.RootFinding;

namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = 0;
            while (t != 10)
            {
                var input = Console.ReadLine().Split(" + ");
                var coefficients = new double[input.Length];
                var j = 0;
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (input[i].Contains('^'))
                        coefficients[j] =
                            double.Parse(input[i].Substring(0, input[i].IndexOf('^')).Trim('(', ')', 'x', '*'));
                    else
                        coefficients[j] = double.Parse(input[i].Trim(')', '(', 'x', '*'));
                    j++;
                }



                double Func(double x) => Evaluate.Polynomial(x, coefficients);
                try
                {
                    Console.WriteLine((Brent.FindRootExpand(Func, -10, 10, 1e-25, 1000)));
                }
                catch
                {
                    // ignored
                }

                try
                {
                    Console.WriteLine((Brent.FindRootExpand(Func, -50, 50, 1e-25, 1000)));
                }
                catch
                {
                    // ignored
                }

                try
                {
                    Console.WriteLine((Brent.FindRootExpand(Func, -100, 10, 1e-25, 1000)));
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}