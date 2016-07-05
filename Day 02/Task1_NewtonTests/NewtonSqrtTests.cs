using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task1_Newton;

namespace Task1_NewtonTests
{
    [TestClass]
    public class NewtonSqrtTests
    {
        public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext { get; set; }

        [TestMethod]
        public void Sqrt_TheRootOfThe2Degree4_2()
        {
            //Arange
            double num = 4;
            int n = 2;
            //Act
            double expectedResult = 2;
            double realResult = NewtonSqrt.Sqrt(num, n);
            //Assert
            Assert.AreEqual(expectedResult,realResult,0.00001);
        }

        [TestMethod]
        public void Sqrt_TheRootOfThe4Degree81epsilon0dot0000001_3()
        {
            //Arange
            double num = 81;
            int n = 4;
            double eps = 0.0000001;
            //Act
            double expectedResult = 3;
            double realResult = NewtonSqrt.Sqrt(num, n,eps);
            //Assert
            Assert.AreEqual(expectedResult, realResult, 0.0000001);
        }

        [TestMethod]
        public void Sqrt_nLesserThan2_NaN()
        {
            //Arange
            double num = 4;
            int n = 1;
            //Act
            double expectedResult = double.NaN;
            double realResult = NewtonSqrt.Sqrt(num, n);
            //Assert
            Assert.AreEqual(expectedResult, realResult);
           
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "../../NewtonSqrtTestData.xml", "testunit", DataAccessMethod.Sequential)]
        [TestMethod]    
        public void Sqrt_TestDatasFromXml()
        {
            
            //Arange
            double num = Double.Parse(TestContext.DataRow["num"].ToString());
            int n = Int32.Parse(TestContext.DataRow["n"].ToString()); 
            //Act
            double expectedResult = Double.Parse(TestContext.DataRow["result"].ToString());
            double realResult = NewtonSqrt.Sqrt(num, n);
            //Assert
            if (Double.IsNaN(expectedResult))
            {
                Assert.AreEqual(expectedResult, realResult);
            }  
            else
            {
                Assert.AreEqual(expectedResult, realResult,0.0000001);
            }
        }

        [TestMethod]
        public void Sqrt_TheRootOfThe2Degree9_3()
        {
            //Arange
            double num = 9;
            //Act
            double expectedResult = 3;
            double realResult = NewtonSqrt.Sqrt(num);
            //Assert
            Assert.AreEqual(expectedResult, realResult, 0.00001);
        }

        [TestMethod]
        public void Sqrt_TheRootOfThe2DegreeNegative9_3()
        {
            //Arange
            double num = -9;
            //Act
            double expectedResult = Double.NaN;
            double realResult = NewtonSqrt.Sqrt(num);
            //Assert
            Assert.AreEqual(expectedResult, realResult, 0.00001);
        }

    }
}
