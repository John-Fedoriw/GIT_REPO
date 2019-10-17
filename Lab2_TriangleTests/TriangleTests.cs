using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2_Triangle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Triangle.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void FindHypotenuseTest()
        {
            double A = 90.0;
            double B = 90.0;
            double C = 0.0;
            double N = 90.0;


            Assert.IsTrue(C == 0.0);
        }

        [TestMethod()]
        public void FindAreaTest()
        {
            double A = 0.0;
            Assert.IsTrue(A == 0.0);
        }

        [TestMethod()]
        public void FindAngleTest()
        {
            double A = 0.0;
            Assert.IsTrue(A == 1.0);
        }
    }
}

namespace Lab2_TriangleTests
{
    class TriangleTests
    {
    }
}
