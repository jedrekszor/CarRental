using System;
using DataLayer.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseManagerTests
{
    [TestClass]
    public class DatabaseManagerTest
    {
        [TestMethod]
        public void AddingCarTest()
        {
            var amountBefore = DatabaseManager.CountAllCars();
            DatabaseManager.AddCar("test", "brand", "model", 100, 4, 10);
            var amountAfter = DatabaseManager.CountAllCars();

            Assert.IsTrue(amountAfter > amountBefore);
            DatabaseManager.RemoveCar("test");
        }
    }
}
