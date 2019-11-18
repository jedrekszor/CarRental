using System;
using DataLayer.Data;
using NUnit.Framework;

namespace TestDataLayer
{
    class OrderTest
    {
        [TestFixture]
        public class Tests
        {
            [Test]
            public void DefaultConstructorTest()
            {
                Order order = new Order();

                Assert.AreEqual("unknown", order.OrderId);
                Assert.NotNull(order.Car);
                Assert.NotNull(order.Client);
                Assert.AreEqual(new DateTime(), order.RentDate);
                Assert.AreEqual(new DateTime(), order.ReturnDate);
                Assert.AreEqual(0, order.Price);
            }

            [Test]
            public void CustomConstructorTest()
            {
                Car car = new Car("no", "brand", "model", 1000, 5, 10);
                Client client = new Client("name", "surname", "licNo", 25);
                Order order = new Order(car, client, new DateTime(), new DateTime());

                Assert.AreEqual("nsno", order.OrderId);
                Assert.AreEqual(car, order.Car);
                Assert.AreEqual(client, order.Client);
                Assert.AreEqual(new DateTime(), order.RentDate);
                Assert.AreEqual(new DateTime(), order.ReturnDate);
                Assert.AreEqual(10, order.Price);
            }
        }
    }
}