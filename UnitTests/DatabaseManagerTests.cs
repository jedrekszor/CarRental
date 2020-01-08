using System;
using System.Diagnostics;
using System.Windows;
using DataLayer.Data;
using DataLayer.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DatabaseManagerTests
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

        [TestMethod]
        public void AddingCarObjTest()
        {
            var amountBefore = DatabaseManager.CountAllCars();
            DatabaseManager.AddCar(new Car("test", "brand", "model", 100, 4, 10));
            var amountAfter = DatabaseManager.CountAllCars();

            Assert.IsTrue(amountAfter > amountBefore);
            DatabaseManager.RemoveCar("test");
        }

        [TestMethod]
        public void RemovingCarTest()
        {
            DatabaseManager.AddCar(new Car("test", "brand", "model", 100, 4, 10));

            var amountBefore = DatabaseManager.CountAllCars();
            DatabaseManager.RemoveCar("test");
            var amountAfter = DatabaseManager.CountAllCars();

            Assert.IsTrue(amountAfter < amountBefore);
        }

        [TestMethod]
        public void GetCarTest()
        {
            DatabaseManager.AddCar("testAdd", "brand", "model", 1000, 5, 10);

            var car1 = DatabaseManager.GetCar("testAdd");
            var car2 = new Car("testAdd", "brand", "model", 1000, 5, 10);

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());

            DatabaseManager.RemoveCar("testAdd");

            Assert.IsTrue(car1.Equals(car2));
        }

        [TestMethod]
        public void UpdateCarTest()
        {
            //var manager = new DbManager();
            DatabaseManager.AddCar("test", "brand", "model", 100, 4, 10);
            DatabaseManager.UpdateCar("test", "brand1", "model1", 110, 5, 11);

            var car1 = DatabaseManager.GetCar("test");
            var car2 = new Car("test", "brand1", "model1", 110, 5, 11);

            DatabaseManager.RemoveCar("test");

            Assert.IsTrue(car1.Equals(car2));
        }

        [TestMethod]
        public void AddingClientTest()
        {
            var amountBefore = DatabaseManager.CountAllClients();
            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 25);
            var amountAfter = DatabaseManager.CountAllClients();

            Assert.IsTrue(amountAfter > amountBefore);
            DatabaseManager.RemoveClient("nsli");
        }

        [TestMethod]
        public void AddingClientObjTest()
        {
            var client = new Client();

            var amountBefore = DatabaseManager.CountAllClients();
            DatabaseManager.AddClient(client);
            var amountAfter = DatabaseManager.CountAllClients();
            Assert.IsTrue(amountAfter > amountBefore);
        }

        [TestMethod]
        public void RemovingClientTest()
        {
            var client = new Client();

            var amountBefore = DatabaseManager.CountAllClients();
            DatabaseManager.RemoveClient(client.Id);
            var amountAfter = DatabaseManager.CountAllClients();

            Assert.IsTrue(amountAfter <= amountBefore);
        }

        [TestMethod]
        public void RemovingClientObjTest()
        {
            var client = new Client();

            DatabaseManager.AddClient(client);

            var amountBefore = DatabaseManager.CountAllClients();
            DatabaseManager.RemoveClient(client.Id);
            var amountAfter = DatabaseManager.CountAllClients();

            Assert.IsTrue(amountAfter < amountBefore);
        }

        [TestMethod]
        public void GetClientTest()
        {
            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 50);

            Client client1 = DatabaseManager.GetClient("nsli");
            var client2 = new Client("name", "surname", "licNo", 50);

            DatabaseManager.RemoveClient("nsli");

            Assert.IsTrue(client1.Equals(client2));
        }

        public void GetClientNameSurnameTest()
        {
            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 50);

            Client client1 = DatabaseManager.GetClient("name", "surname");
            var client2 = new Client("name", "surname", "licNo", 50);

            DatabaseManager.RemoveClient("nsli");

            Assert.IsTrue(client1.Equals(client2));
        }

        [TestMethod]
        public void UpdateClientTest()
        {
            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 50);
            DatabaseManager.UpdateClient("nsli", "name1", "surname1", "licNo1", 55);

            var client1 = DatabaseManager.GetClient("nsli");
            var client2 = new Client("name1", "surname1", "licNo1", 55);

            DatabaseManager.RemoveClient("nsli");

            Assert.IsTrue(client1.Equals(client2));
        }

        [TestMethod]
        public void ClientIfExistsTest()
        {
            bool check1 = DatabaseManager.IfClientExists("name", "surname");

            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 50);

            bool check = DatabaseManager.IfClientExists("name", "surname");
            DatabaseManager.RemoveClient("nsli");

            Assert.IsFalse(check1);
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void AddOrderObjTest()
        {
            var date = DateTime.Today;

            var car = new Car();
            var client = new Client();
            var order = new Order(car, client, date, date);

            var beforeAmountAdd = DatabaseManager.CountAllOrders();

            DatabaseManager.AddClient(client);
            DatabaseManager.AddCar(car);
            DatabaseManager.AddOrder(order);

            var afterAmountAdd = DatabaseManager.CountAllOrders();

            Assert.IsTrue(afterAmountAdd > beforeAmountAdd);
        }

        [TestMethod]
        public void RemoveOrderTest()
        {
            var beforeAmount = DatabaseManager.CountAllOrders();
            DatabaseManager.RemoveOrder("ccca");
            var afterAmount = DatabaseManager.CountAllOrders();

            DatabaseManager.RemoveCar(new Car().LicenceNo);
            DatabaseManager.RemoveClient(new Client().Id);
            Assert.IsTrue(afterAmount <= beforeAmount);
        }

        [TestMethod]
        public void GettingOrderTest()
        {
            Car car = new Car();
            Client client = new Client();
            Order order = new Order(car, client, DateTime.Today, DateTime.Today);

            DatabaseManager.AddCar(car);
            DatabaseManager.AddClient(client);
            DatabaseManager.AddOrder(order);

            Order order1 = DatabaseManager.GetOrder(order.OrderId);

            DatabaseManager.RemoveOrder(order);
            DatabaseManager.RemoveClient(client);
            DatabaseManager.RemoveCar(car);

            Assert.IsTrue(order1.Equals(order));
        }

        [TestMethod]
        public void IfNotOccupiedCarCheck()
        {
            Car car = new Car();
            Client client = new Client();
            DatabaseManager.RemoveCar(car);
            DatabaseManager.RemoveClient(client);

            DatabaseManager.AddCar(car);
            DatabaseManager.AddClient(client);

            Order order = new Order(car, client, DateTime.Today, DateTime.Today);
            DatabaseManager.RemoveOrder(order);

            bool checkBefore = DatabaseManager.IfNotOccupied(car);
            DatabaseManager.AddOrder(order);
            bool checkAfter = DatabaseManager.IfNotOccupied(car);

            DatabaseManager.RemoveOrder(order);
            DatabaseManager.RemoveCar(car);
            DatabaseManager.RemoveClient(client);

            Assert.IsFalse(checkBefore);
            Assert.IsTrue(checkAfter);
        }

        [TestMethod]
        public void IfNotOccupiedClientCheck()
        {
            Car car = new Car();
            Client client = new Client();
            DatabaseManager.RemoveCar(car);
            DatabaseManager.RemoveClient(client);

            DatabaseManager.AddCar(car);
            DatabaseManager.AddClient(client);

            Order order = new Order(car, client, DateTime.Today, DateTime.Today);
            DatabaseManager.RemoveOrder(order);

            bool checkBefore = DatabaseManager.IfNotOccupied(client);
            DatabaseManager.AddOrder(order);
            bool checkAfter = DatabaseManager.IfNotOccupied(client);

            DatabaseManager.RemoveOrder(order);
            DatabaseManager.RemoveCar(car);
            DatabaseManager.RemoveClient(client);

            Assert.IsFalse(checkBefore);
            Assert.IsTrue(checkAfter);
        }

        [TestMethod]
        public void IfClientExistsTest()
        {
            Client client = new Client();
            DatabaseManager.RemoveClient(client);
            bool checkBefore = DatabaseManager.IfClientExists(client.Name, client.Surname);

            DatabaseManager.AddClient(client);
            bool checkAfter = DatabaseManager.IfClientExists(client.Name, client.Surname);

            DatabaseManager.RemoveClient(client);

            Assert.IsFalse(checkBefore);
            Assert.IsTrue(checkAfter);
        }

        [TestMethod]
        public void ArchiveOrderTest()
        {
            Order order = new Order();
            DatabaseManager.ArchiveOrder(order, 1000, 1500, "gut");
        }

        [TestMethod]
        public void GetOrderTest()
        {
            Order order = new Order();
            Car car = new Car();
            Client client = new Client();

            DatabaseManager.RemoveOrder(order);
            DatabaseManager.RemoveCar(car);
            DatabaseManager.RemoveClient(client);

            DatabaseManager.AddCar(car);
            DatabaseManager.AddClient(new Client());
            DatabaseManager.AddOrder(order);

            Order order1 = DatabaseManager.GetOrder(order.Client.Name, order.Client.Surname);

            DatabaseManager.RemoveOrder(order);
            DatabaseManager.RemoveCar(car);
            DatabaseManager.RemoveClient(client);

            Assert.IsTrue(order.Equals(order1));

        }
    }
}