using System;
using NUnit.Framework;
using Task2_GCD;
namespace Task2_GCD.NTests
{
    [TestFixture]
    public class GcdMathEwclideNTests
    {
        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        [TestCase(0,0)]
        public void EwclideGcd_ZeroExeption(int a,int b)
        {
            GcdMath.EwclideGcd(a, b);
        }

        [Test]
        [TestCase(Int32.MaxValue, Int32.MaxValue,Int32.MaxValue)]
        [TestCase(Int32.MinValue,Int32.MinValue,Int32.MinValue)]
        [TestCase(0, 100,100)]
        [TestCase(-100, 0,-100)]
        [TestCase(1000,10,10)]
        [TestCase(-500, -13, 1)]
        [TestCase(-13, 17, 1)]
        public void EwclideGcd_Num1_Num2_Result(int a, int b, int res)
        {
            Assert.AreEqual(res, GcdMath.EwclideGcd(a, b));
        }

        [Test]
        [TestCase(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue)]
        [TestCase(Int32.MinValue, Int32.MinValue, Int32.MinValue, Int32.MinValue)]
        [TestCase(1,32,25,65,87,-1,23,543,65,876)]
        [TestCase(10,10,20,30,40,50,60,70)]
        [TestCase(7,14,21,21)]
        [TestCase(8,8)]
        public void EwclideGcd_Result_Args(int res,params int[] arg)
        {
            Assert.AreEqual(res, GcdMath.EwclideGcd(arg));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCase()]
        public void EwclideGcd_Args_ArgumentNullExeption()
        {
            GcdMath.EwclideGcd();
        }

        [Test]
        [TestCase(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue)]
        [TestCase(Int32.MinValue, Int32.MinValue, Int32.MinValue, Int32.MinValue)]
        [TestCase(10,7,null,1)]
        [TestCase(16, 4, 10,4)]
        public void EwclideGcd_Num1_Num2_BufferForTime_result(int a,int b,double buf,int res)
        {
            Assert.AreEqual(res, GcdMath.EwclideGcd(a,b,out buf));
        }
    }
}