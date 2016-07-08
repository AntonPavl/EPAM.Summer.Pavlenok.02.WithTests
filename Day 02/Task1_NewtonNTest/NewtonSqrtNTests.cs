using System;
using NUnit.Framework;
using Task1_Newton;
namespace Task1_NewtonNTest
{
    [TestFixture]
    public class NewtonSqrtNTests
    {
        [Test]
        [TestCase(4, 2, 2)]
        [TestCase(16, 2, 4)]
        [TestCase(81, 4, 3)]
        [TestCase(0,3,0)]
        [TestCase(Int32.MaxValue, 2, 46340.95000105)]
        public void Sqrt_Num_Root_Result(double num, int n, double res)
        {
                Assert.AreEqual(NewtonSqrt.Sqrt(num, n), res, 0.0000001);
        }
        [Test]
        [TestCase(-81, 4, double.NaN)]
        [TestCase(Int32.MinValue, 2, Double.NaN)]
        public void Sqrt_Num_Root_NaN(double num, int n, double res)
        {
                Assert.AreEqual(NewtonSqrt.Sqrt(num, n), res);
        }
    }
}