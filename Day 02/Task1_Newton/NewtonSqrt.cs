using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Newton
{
    /// <summary>
    /// Evaluate square root by Newton's method
    /// </summary>
    public class NewtonSqrt
    {

        /// <summary>
        /// Evaluate num^(1/2)
        /// </summary>
        /// <param name="num">Number under the root</param>
        /// <returns>Returns num^(1/2)</returns>
        public static double Sqrt(double num)
        {
            return Sqrt(num, 2);
        }
        /// <summary>
        /// Evaluate num^(1/2) and save worktime
        /// </summary>
        /// <param name="num">Number under the root</param>
        /// <param name="workedtime">Buffer for worktime</param>
        /// <returns>Returns num^(1/2)</returns>
        public static double Sqrt(double num, out double workedtime)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = Sqrt(num);
            watch.Stop();
            workedtime = watch.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Evaluate num^(1/n)
        /// </summary>
        /// <param name="num">Number under the root</param>
        /// <param name="n">Root level</param>
        /// <returns>Returns num^(1/n)</returns>
        public static double Sqrt(double num, int n)
        {
            return Sqrt(num, n, 0.0000001);
        }


        /// <summary>
        /// Evaluate num^(1/n) and save worktime
        /// </summary>
        /// <param name="num">Number under the root</param>
        /// <param name="n">Root level</param>
        /// <param name="workedtime">Buffer for worktime</param>
        /// <returns>Returns num^(1/n)</returns>
        public static double Sqrt(double num, int n,out double workedtime)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
             var res = Sqrt(num, n);
            watch.Stop();
            workedtime = watch.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Evaluate num^(1/n) with epsilon
        /// </summary>
        /// <param name="num">Number under the root</param>
        /// <param name="n">Root level</param>
        /// <param name="eps">Epsilon of result. Must be less than 1 else default eps </param>
        /// <returns>Returns num^(1/n)</returns>
        public static double Sqrt(double num, int n, double eps)
        {
            if (eps >= 1) eps = 0.0000001;
            if (n < 2) return Double.NaN;
            if (n % 2 == 0 && num <= 0) return Double.NaN;
            if (num == 0) return 0;
            double res = num;
            double prev = 0;
            while (Math.Abs(prev - res) >= eps)
            {
                prev = res;
                res = (1.0 / n) * ((n - 1) * res + num / (Math.Pow(res, n - 1)));
            }
            return res;
        }

        /// <summary>
        /// Evaluate num^(1/n) with epsilon and save worktime
        /// </summary>
        /// <param name="num">Number under the root</param>
        /// <param name="n">Root level</param>
        /// <param name="eps">Epsilon of result. Must be less than 1 else default eps </param>
        /// <param name="workedtime">number of ticks</param>
        /// <returns>Returns num^(1/n)</returns>
        public static double Sqrt(double num, int n, double eps,out double workedtime)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
              var res = Sqrt(num, n, eps);
            watch.Stop();
            workedtime = watch.ElapsedTicks;
            return res;
        }


    }
}
