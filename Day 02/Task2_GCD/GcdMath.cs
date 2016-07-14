using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_GCD
{
    public static class GcdMath
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
        public static int EwclideGcd(params int[] arg) =>
            MultiGCD(EwclideGcd, arg);

        /// <summary>
        /// computes the greatest common divisor with Ewklide's algorithm and save worktime
        /// </summary>
        /// <param name="a">First natural number</param>
        /// <param name="b">Second natural number</param>
        /// <param name="workedtime">Buffer for worktime</param>
        /// <returns>gcd(a,b)</returns>
        public static int EwclideGcd(int a, int b, out double workedtime) =>
            TimeDiagnostic(EwclideGcd, a, b, out workedtime);


        /// <summary>
        /// computes the greatest common divisor with Ewklide's algorithm with multiple arguments and save worktime
        /// </summary>
        /// <param name="workedtime">Buffer for worktime</param>
        /// <param name="arg">Natural numbers</param>
        /// <returns>gcd(args)</returns>
        public static int EwclideGcd(out double workedtime,params int[] arg) =>
            TimeDiagnostic(EwclideGcd, arg, out workedtime);

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
        public static int SteineGcd(params int[] arg) =>
            MultiGCD(SteineGcd, arg);


        /// <summary>
        /// computes the greatest common divisor with Steine's algorithm and save worktime
        /// </summary>
        /// <param name="a">First natural number</param>
        /// <param name="b">Second natural number</param>
        /// <param name="workedtime">Buffer for wroktime</param>
        /// <returns>gcd(a,b)</returns>
        public static int SteineGcd(int a, int b, out double workedtime) =>
            TimeDiagnostic(SteineGcd, a, b,out workedtime);

        /// <summary>
        /// computes the greatest common divisor with Steine's algorithm with multiple arguments and save worktime
        /// </summary>
        /// <param name="workedtime">Buffer for worktime</param>
        /// <param name="arg">Natural numbers</param>
        /// <returns>gcd(args)</returns>
        public static int SteineGcd(out double workedtime, params int[] arg) =>
            TimeDiagnostic(SteineGcd, arg, out workedtime);

        private static int MultiGCD(Func<int,int,int> f,int[] arg)
        {
            if (arg.Length == 0) throw new ArgumentNullException();
            if (arg.Length == 1) return arg[0];
            int temp = arg[0];
            foreach (var item in arg)
            {
                temp = f(temp, item);
            }
            return temp;
        }
        private static int TimeDiagnostic(Func<int, int, int> f, int a, int b, out double workedtime) =>
            TimeDiagnostic((int[] x) => f(x[0],x[1]), new int[2] { a, b }, out workedtime);

        private static int TimeDiagnostic(Func<int[],int> f, int[] arg, out double workedtime)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = f(arg);
            watch.Stop();
            workedtime = watch.ElapsedTicks;
            return res;
        }

    }
}
