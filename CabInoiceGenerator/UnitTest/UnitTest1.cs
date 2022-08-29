
using System.Collections.Generic;
using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Tests
    {
        InvoiceGenerator invoiceGeneratorNormalRide;

        [TestMethod]
        public void Setup()
        {
            invoiceGeneratorNormalRide = new InvoiceGenerator();
        }
        /// <summary>
        /// UC1:Calculate the normal ride fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <param name="output"></param>

        [TestMethod]
        public void GivenTimeAndDistance_CalculateFare(double distance, double time)
        {
            Ride ride = new Ride(distance, time);
            int excepted = 53;
            Assert.AreEqual(excepted, invoiceGeneratorNormalRide.TotalFareForSingleRiderreturn(ride));
        }
        //1.1: Check for invalid distance
        [TestMethod]
        public void GivenInvalidDistance_ThrowException()
        {
            Ride ride = new Ride(-1, 1);
            InvoiceGeneratorException invoiceGeneratorException = Assert.ThrowsException<InvoiceGeneratorException>(() => invoiceGeneratorNormalRide.TotalFareForSingleRiderreturn(ride));
            Assert.AreEqual(invoiceGeneratorException.type, InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE);
        }
        //TC1.2: Check for invalid time
        [TestMethod]
        public void GivenInvalidTime_ThrowException()
        {
            Ride ride = new Ride(1, -1);
            InvoiceGeneratorException invoiceGeneratorException2 = Assert.ThrowsException<InvoiceGeneratorException>(() => invoiceGeneratorNormalRide.TotalFareForSingleRiderreturn(ride));
            Assert.AreEqual(invoiceGeneratorException2.type, InvoiceGeneratorException.ExceptionType.INVALID_TIME);
        }
    }
}