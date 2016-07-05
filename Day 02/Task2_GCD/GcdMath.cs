using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_GCD
{
    public class GcdMath
    {
        /// <summary>
        /// computes the greatest common divisor with Ewklide's algorithm
        /// </summary>
        /// <param name="a">First natural number</param>
        /// <param name="b">Second natural number</param>
        /// <returns>gcd(a,b)</returns>
        public static int EwclideGcd(int a, int b)
        {
            if (a == 0 && b == 0) throw new DivideByZeroException();
            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a;
            a = a > 0 ? a : a * -1;
            b = b > 0 ? b : b * -1;
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }

        /// <summary>
        /// computes the greatest common divisor with Ewklide's algorithm with multiple arguments
        /// </summary>
        /// <param name="arg">Natural numbers</param>
        /// <returns>gcd(args)</returns>
        public static int EwclideGcd(params int[] arg) 
        {
            if (arg.Length == 0) throw new ArgumentNullException();
            if (arg.Length == 1) return arg[0];
            int temp = arg[0];
            foreach (var item in arg)
            {
                temp = EwclideGcd(temp, item);
            }
            return temp;
        }

        /// <summary>
        /// computes the greatest common divisor with Ewklide's algorithm and save worktime
        /// </summary>
        /// <param name="a">First natural number</param>
        /// <param name="b">Second natural number</param>
        /// <param name="workedtime">Buffer for worktime</param>
        /// <returns>gcd(a,b)</returns>
        public static int EwclideGcd(int a, int b,out double workedtime)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = EwclideGcd(a, b);
            watch.Stop();
            workedtime = watch.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// computes the greatest common divisor with Ewklide's algorithm with multiple arguments and save worktime
        /// </summary>
        /// <param name="workedtime">Buffer for worktime</param>
        /// <param name="arg">Natural numbers</param>
        /// <returns>gcd(args)</returns>
        public static int EwclideGcd(out double workedtime,params int[] arg)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = EwclideGcd(arg);
            watch.Stop();
            workedtime = watch.ElapsedTicks;
            return res;
        }



        /// <summary>
        /// computes the greatest common divisor with Steine's algorithm
        /// </summary>
        /// <param name="a">First natural number</param>
        /// <param name="b">Second natural number</param>
        /// <returns>gcd(a,b)</returns>
        public static int SteineGcd(int a,int b)
        {
            if (a == 0 && b == 0) throw new DivideByZeroException();
            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a;
            a = a > 0 ? a : a * -1;
            b = b > 0 ? b : b * -1;
            if ((a & 1)==0) // a is even
            {
                if ((b & 1)==1) return SteineGcd(a/2, b); // b is odd
                else return SteineGcd(a/2, b/2) * 2;      // a is even , b is even
            }

            if ((b & 1)==0) return SteineGcd(a, b/2); //b is even, a is odd

            if (a > b) return SteineGcd((a - b)/2, b); //a is odd, b is odd

            return SteineGcd((b - a)/2, a); // a is odd, b is odd and b>a
        }

        /// <summary>
        /// SteineGcd with multiple arguments
        /// </summary>
        /// <param name="arg">Natural numbers</param>
        /// <returns>gcd(args)</returns>
        public static int SteineGcd(params int[] arg)
        {

            if (arg.Length == 0) throw new ArgumentNullException();
            if (arg.Length == 1) return arg[0];
            int temp = arg[0];
            foreach (var item in arg)
            {
                temp = SteineGcd(temp, item);
            }
            return temp;
        }

        /// <summary>
        /// computes the greatest common divisor with Steine's algorithm and save worktime
        /// </summary>
        /// <param name="a">First natural number</param>
        /// <param name="b">Second natural number</param>
        /// <param name="workedtime">Buffer for wroktime</param>
        /// <returns>gcd(a,b)</returns>
        public static int SteineGcd(int a, int b, out double workedtime)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = SteineGcd(a, b);
            watch.Stop();
            workedtime = watch.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// computes the greatest common divisor with Steine's algorithm with multiple arguments and save worktime
        /// </summary>
        /// <param name="workedtime">Buffer for worktime</param>
        /// <param name="arg">Natural numbers</param>
        /// <returns>gcd(args)</returns>
        public static int SteineGcd(out double workedtime, params int[] arg)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = SteineGcd(arg);
            watch.Stop();
            workedtime = watch.ElapsedTicks;
            return res;
        }
    }
}
