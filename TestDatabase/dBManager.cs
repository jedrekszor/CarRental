using System;
using DataLayer.Data;
using DataLayer.Database;
using NUnit.Framework;

namespace TestDatabase
{
    [TestFixture]
    class DbManagerTest
    {
        #region CarTests

        // adding car with given parameters
        [Test]
        public void AddingCarTest()
        {
            var amountBefore = DatabaseManager.CountAllCars();
            DatabaseManager.AddCar("test", "brand", "model", 100, 4, 10);
            var amountAfter = DatabaseManager.CountAllCars();

            Assert.Greater(amountAfter, amountBefore);
            DatabaseManager.RemoveCar("test");
        }

        // adding car with given object
        [Test]
        public void AddingCarObjTest()
        {
            var amountBefore = DatabaseManager.CountAllCars();
            DatabaseManager.AddCar(new Car("test", "brand", "model", 100, 4, 10));
            var amountAfter = DatabaseManager.CountAllCars();

            Assert.Greater(amountAfter, amountBefore);
            DatabaseManager.RemoveCar("test");
        }

        // removing car with given parameters
        [Test]
        public void RemovingCarTest()
        {
            DatabaseManager.AddCar(new Car("test", "brand", "model", 100, 4, 10));

            var amountBefore = DatabaseManager.CountAllCars();
            DatabaseManager.RemoveCar("test");
            var amountAfter = DatabaseManager.CountAllCars();

            Assert.Less(amountAfter, amountBefore);
        }

        // getting car form database
        [Test]
        public void GetCarTest()
        {
            DatabaseManager.AddCar("testAdd", "brand", "model", 1000, 5, 10);

            var car1 = DatabaseManager.GetCar("testAdd");
            var car2 = new Car("testAdd", "brand", "model", 1000, 5, 10);

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());

            DatabaseManager.RemoveCar("testAdd");

            Assert.True(car1.Equals(car2));
        }

        // updating car info in database
        [Test]
        public void UpdateCarTest()
        {
            DatabaseManager.AddCar("test", "brand", "model", 100, 4, 10);
            DatabaseManager.UpdateCar("test", "brand1", "model1", 110, 5, 11);

            var car1 = DatabaseManager.GetCar("test");
            var car2 = new Car("test", "brand1", "model1", 110, 5, 11);

            DatabaseManager.RemoveCar("test");

            Assert.True(car1.Equals(car2));
        }

        #endregion

        //        ---------------------------------------------------------------------------------------------

        #region ClientTests

        // Adding client with parameters
        [Test]
        public void AddingClientTest()
        {
            var amountBefore = DatabaseManager.CountAllClients();
            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 25);
            var amountAfter = DatabaseManager.CountAllClients();

            Assert.Greater(amountAfter, amountBefore);
            DatabaseManager.RemoveClient("nsli");
        }

        // Adding client with object
        [Test]
        public void AddingClientObjTest()
        {
            var client = new Client();

            var amountBefore = DatabaseManager.CountAllClients();
            DatabaseManager.AddClient(client);
            var amountAfter = DatabaseManager.CountAllClients();

            DatabaseManager.RemoveClient(client.Id);
            Assert.Greater(amountAfter, amountBefore);
        }

        // removing client with given parameters
        [Test]
        public void RemovingClientTest()
        {
            var client = new Client();
            DatabaseManager.AddClient(client);

            var amountBefore = DatabaseManager.CountAllClients();
            DatabaseManager.RemoveClient(client.Id);
            var amountAfter = DatabaseManager.CountAllClients();

            Assert.Less(amountAfter, amountBefore);
        }

        // removing client with given object
        [Test]
        public void RemovingClientObjTest()
        {
            var client = new Client();

            DatabaseManager.AddClient(client);

            var amountBefore = DatabaseManager.CountAllClients();
            DatabaseManager.RemoveClient(client.Id);
            var amountAfter = DatabaseManager.CountAllClients();

            Assert.Less(amountAfter, amountBefore);
        }

        // get client as object form database
        [Test]
        public void GetClientTest()
        {
            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 50);

            Client client1 = DatabaseManager.GetClient("nsli");
            var client2 = new Client("name", "surname", "licNo", 50);

            DatabaseManager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        public void GetClientNameSurnameTest()
        {
            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 50);

            Client client1 = DatabaseManager.GetClient("name", "surname");
            var client2 = new Client("name", "surname", "licNo", 50);

            DatabaseManager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        // update client info in database
        [Test]
        public void UpdateClientTest()
        {
            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 50);

            DatabaseManager.UpdateClient("nsli", "name1", "surname1", "licNo1", 55);

            var client1 = DatabaseManager.GetClient("nsli");
            var client2 = new Client("name1", "surname1", "licNo1", 55);

            DatabaseManager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        [Test]
        public void ClientIfExistsTest()
        {
            bool check1 = DatabaseManager.IfClientExists("name", "surname");

            DatabaseManager.AddClient("nsli", "name", "surname", "licNo", 50);

            bool check = DatabaseManager.IfClientExists("name", "surname");
            DatabaseManager.RemoveClient("nsli");

            Assert.False(check1);
            Assert.True(check);
        }

        #endregion

        //        ---------------------------------------------------------------------------------------------

        #region OrderTests

        [Test]
        public void AddOrderObjTest()
        {
            var date = DateTime.Today;

            var car = new Car("test", "brand", "model", 10, 5, 10);
            var client = new Client("name", "surname", "licNo", 50);
            var order = new Order(car, client, date, date);

            var beforeAmount = DatabaseManager.CountAllOrders();
            DatabaseManager.AddOrder(order);
            var afterAmount = DatabaseManager.CountAllOrders();

            Assert.Greater(afterAmount, beforeAmount);
        }

        [Test]
        public void RemoveOrderTest()
        {
            var beforeAmount = DatabaseManager.CountAllOrders();
            DatabaseManager.RemoveOrder("nste");
            var afterAmount = DatabaseManager.CountAllOrders();

            Assert.Less(afterAmount, beforeAmount);
        }

        [Test]
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

            Assert.True(order1.Equals(order));
        }

        #endregion

        #region DataLogic

        [Test]
        public void IfNotOccupiedCarCheck()
        {
            Car car = new Car();
            Order order = new Order(car, new Client(), DateTime.Today, DateTime.Today);

            bool checkBefore = DatabaseManager.IfNotOccupied(car);
            DatabaseManager.AddOrder(order);
            bool checkAfter = DatabaseManager.IfNotOccupied(car);

            DatabaseManager.RemoveOrder(order);
            Assert.False(checkBefore);
            Assert.True(checkAfter);
        }

        [Test]
        public void IfNotOccupiedClientCheck()
        { 
            Client client = new Client();
            Order order = new Order(new Car(), client, DateTime.Today, DateTime.Today);

            bool checkBefore = DatabaseManager.IfNotOccupied(client);
            DatabaseManager.AddOrder(order);
            bool checkAfter = DatabaseManager.IfNotOccupied(client);

            DatabaseManager.RemoveOrder(order);
            Assert.False(checkBefore);
            Assert.True(checkAfter);
        }

        #endregion
    }
}