using System.Collections.Generic;
using System.ComponentModel;
using DataLayer.Data;
using DataLayer.Database;
using NUnit.Framework;

namespace TestDataLayer
{
    [TestFixture]
    public class CarTest
    {
        [Test]
        public void DefaultConstructorTest()
        {
            Car car = new Car();
            Assert.AreEqual(car.LicenceNo, "car_LicenceNo");
            Assert.AreEqual(car.Brand, "car_brand");
            Assert.AreEqual(car.Model, "car_model");
            Assert.AreEqual(car.Mileage, 0);
            Assert.AreEqual(car.Passengers, 0);
            Assert.AreEqual(car.Price, 0);
        }

        [Test]
        public void CustomConstructorTest()
        {
            Car car = new Car("licenceNo", "brand", "model", 10, 5, 10);
            Assert.AreEqual(car.LicenceNo, "licenceNo");
            Assert.AreEqual(car.Brand, "brand");
            Assert.AreEqual(car.Model, "model");
            Assert.AreEqual(car.Mileage, 10);
            Assert.AreEqual(car.Passengers, 5);
            Assert.AreEqual(car.Price, 10);
        }

        [Test]
        public void SetterMileageTest()
        {
            Car car = new Car("test1", "brand", "model", 10, 5, 10);
            car.Mileage = 60;
            Assert.AreEqual(60, car.Mileage);

        }

        [Test]
        public void SetterPriceTest()
        {
            Car car = new Car("test1", "brand", "model", 10, 5, 10);
            car.Price = 60;
            Assert.AreEqual(60, car.Price);
        }

        [Test]
        public void PropertiesGettersTest()
        {
            Car car = new Car("test1", "brand", "model", 10, 5, 10);
            var licNo = car.LicenceNo;
            var brand = car.Brand;
            var model = car.Model;
            var mileage = car.Mileage;
            var passengers = car.Passengers;
            var price = car.Price;

            Assert.AreEqual(licNo, "test1");
            Assert.AreEqual(brand, "brand");
            Assert.AreEqual(model, "model");
            Assert.AreEqual(mileage, 10);
            Assert.AreEqual(passengers, 5);
            Assert.AreEqual(price, 10);

        }

        [Test]
        public void INotifyPropertyChangeTest()
        {
            Car car = new Car();

            //creating event monitor
            Dictionary<string, int> receivedEvents = new Dictionary<string, int>();
            car.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if (receivedEvents.ContainsKey(e.PropertyName))
                    receivedEvents[e.PropertyName]++;
                else
                    receivedEvents.Add(e.PropertyName, 1);
            };

            car.Mileage = 10000;
            car.Price = 10000;

            Assert.IsTrue(receivedEvents.ContainsKey("Mileage"));
            Assert.AreEqual(1, receivedEvents["Mileage"]);

            Assert.IsTrue(receivedEvents.ContainsKey("Price"));
            Assert.AreEqual(1, receivedEvents["Price"]);
        }
    }
 }
