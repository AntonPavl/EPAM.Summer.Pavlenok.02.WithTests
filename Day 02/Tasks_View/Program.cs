using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task1_Newton;
using Task2_GCD;

namespace Tasks_View
{
    class Program
    {  
        /// <summary>
        /// Compares Math.Pow and NewtonSqrt.Sqrt results
        /// </summary>
        /// <param name="num">Number under the root</param>
        /// <param name="n">Root level</param>
        /// <param name="eps">Epsilon of result</param>
        static void CompareSqrt(double num, int n,double eps)
        {
            Console.WriteLine($"{num} 1/{n}");
            Console.WriteLine($"Math.Pow = \t {Math.Pow(num,1.0/n)}");
            Console.WriteLine($"Newton   = \t {NewtonSqrt.Sqrt(num,n,eps)}");
            Console.WriteLine("--------------------------------------------------- \n");
        }

        //if Math.Pow shows NaN it does not mean that the GCD is not exist.
        static void Task1View()
        {
            Random rand = new Random();
            CompareSqrt(10, 3, 0.00000001);
            for (int i = 0; i < 20; i++)
            {
                //Range: DoubleNumber(0-100) SquareRoot(2-10) Epsilon = 0.00000001
                CompareSqrt((rand.NextDouble()-0.5) * 100, rand.Next(2, 10), 0.00000001);
            }
            double elapsedMs = 0;
            NewtonSqrt.Sqrt(100, 12,out elapsedMs);
            Console.WriteLine(elapsedMs);
        }

        static void Task2View()
        {
            Console.WriteLine($"10,4 = {GcdMath.EwclideGcd(10,4)}");
            Console.WriteLine($"28,14,8,6,4 = {GcdMath.EwclideGcd(28,14,8,6,4)}");
            Console.WriteLine($"9,3,1,0 ={GcdMath.EwclideGcd(9,3,1,0)}");
            Console.WriteLine($"0,4 ={GcdMath.EwclideGcd(0, 4)}");
            Console.WriteLine($"7,7 = {GcdMath.SteineGcd(7,7)}");
            Console.WriteLine($"28,14,7 = {GcdMath.SteineGcd(28,14,7)}");
            Console.WriteLine($"64,32,16,8,4,2 = {GcdMath.SteineGcd(64,32,16,8,4,2)}");
        }

        static void Main(string[] args)
        {
            Task1View();
            Task2View();
            Console.ReadKey();
        }

    }
}
