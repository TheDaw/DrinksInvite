using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intercom_Drinks;


namespace Drinks_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OneDegreesToRadiansEqual()
        {
            Assert.AreEqual(0.017453, Program.deg2rad(1), 0.00001);
        }

        [TestMethod]
        public void OneDegreesToRadiansNotEqual()
        {
            Assert.AreNotEqual(0.017, Program.deg2rad(1), 0.00001);
        }

        [TestMethod]
        public void HundredDegreesToRadiansEqual()
        {
            Assert.AreEqual(1.745329, Program.deg2rad(100), 0.00001);
        }

        [TestMethod]
        public void HundredDegreesToRadiansNotEqual()
        {
            Assert.AreNotEqual(1.7, Program.deg2rad(100), 0.00001);
        }

        [TestMethod]
        public void OneRadiansToDegreesEqual()
        {
            Assert.AreEqual(57.29577, Program.rad2deg(1), 0.00001);
        }

        [TestMethod]
        public void OneRadiansToDegreesNotEqual()
        {
            Assert.AreNotEqual(57.29, Program.rad2deg(1), 0.00001);
        }

        [TestMethod]
        public void HundredRadiansToDegreesEqual()
        {
            Assert.AreEqual(5729.57795, Program.rad2deg(100), 0.00001);
        }

        [TestMethod]
        public void HundredRadiansToDegreesNotEqual()
        {
            Assert.AreNotEqual(5729, Program.rad2deg(100), 0.00001);
        }

        [TestMethod]
        public void DegreeBacktoRadian()
        {
            double expected = 1;
            double testValue = 1;
            testValue = Program.deg2rad(1);
            testValue = Program.rad2deg(testValue);
            Assert.AreEqual(expected, testValue);
        }

        [TestMethod]
        public void RadianBackToDegree()
        {
            double expected = 1;
            double testValue = 1;
            testValue = Program.rad2deg(1);
            testValue = Program.deg2rad(testValue);
            Assert.AreEqual(expected, testValue);
        }

        [TestMethod]
        public void DistanceToSelf()
        {
            Assert.AreEqual(0, Program.distance(1, 1, 1, 1));
        }

        [TestMethod]
        public void DistanceToDifferentPoint()
        {
            Assert.AreNotEqual(0, Program.distance(1.254158, 1.8878787, 1.548640, 1.262690));
        }


    }
}
