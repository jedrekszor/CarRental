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
            DbManager manager = new DbManager();

            var amountBefore = manager.CountAllCars();
            manager.AddCar("test", "brand", "model", 100, 4, 10);
            var amountAfter = manager.CountAllCars();

            Assert.Greater(amountAfter, amountBefore);
            manager.RemoveCar("test");
        }

        // adding car with given object
        [Test]
        public void AddingCarObjTest()
        {
            DbManager manager = new DbManager();

            var amountBefore = manager.CountAllCars();
            manager.AddCar(new Car("test", "brand", "model", 100, 4, 10));
            var amountAfter = manager.CountAllCars();

            Assert.Greater(amountAfter, amountBefore);
            manager.RemoveCar("test");
        }

        // removing car with given parameters
        [Test]
        public void RemovingCarTest()
        {
            DbManager manager = new DbManager();
            manager.AddCar(new Car("test", "brand", "model", 100, 4, 10));

            var amountBefore = manager.CountAllCars();
            manager.RemoveCar("test");
            var amountAfter = manager.CountAllCars();

            Assert.Less(amountAfter, amountBefore);
        }

        // getting car form database
        [Test]
        public void GetCarTest()
        {
            var manager = new DbManager();
            manager.AddCar("testAdd", "brand", "model", 1000, 5, 10);

            var car1 = manager.GetCar("testAdd");
            var car2 = new Car("testAdd", "brand", "model", 1000, 5, 10);

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());

            manager.RemoveCar("testAdd");

            Assert.True(car1.Equals(car2));
        }

        // updating car info in database
        [Test]
        public void UpdateCarTest()
        {
            var manager = new DbManager();
            manager.AddCar("test", "brand", "model", 100, 4, 10);
            manager.UpdateCar("test", "brand1", "model1", 110, 5, 11);

            var car1 = manager.GetCar("test");
            var car2 = new Car("test", "brand1", "model1", 110, 5, 11);

            manager.RemoveCar("test");

            Assert.True(car1.Equals(car2));
        }

        #endregion

        //        ---------------------------------------------------------------------------------------------

        #region ClientTests

        // Adding client with parameters
        [Test]
        public void AddingClientTest()
        {
            DbManager manager = new DbManager();

            var amountBefore = manager.CountAllClients();
            manager.AddClient("nsli", "name", "surname", "licNo", 25);
            var amountAfter = manager.CountAllClients();

            Assert.Greater(amountAfter, amountBefore);
            manager.RemoveClient("nsli");
        }

        // Adding client with object
        [Test]
        public void AddingClientObjTest()
        {
            DbManager manager = new DbManager();
            var client = new Client();

            var amountBefore = manager.CountAllClients();
            manager.AddClient(client);
            var amountAfter = manager.CountAllClients();

            manager.RemoveClient(client.Id);
            Assert.Greater(amountAfter, amountBefore);
        }

        // removing client with given parameters
        [Test]
        public void RemovingClientTest()
        {
            DbManager manager = new DbManager();
            var client = new Client();
            manager.AddClient(client);

            var amountBefore = manager.CountAllClients();
            manager.RemoveClient(client.Id);
            var amountAfter = manager.CountAllClients();

            Assert.Less(amountAfter, amountBefore);
        }

        // removing client with given object
        [Test]
        public void RemovingClientObjTest()
        {
            DbManager manager = new DbManager();
            var client = new Client();

            manager.AddClient(client);

            var amountBefore = manager.CountAllClients();
            manager.RemoveClient(client.Id);
            var amountAfter = manager.CountAllClients();

            Assert.Less(amountAfter, amountBefore);
        }

        // get client as object form database
        [Test]
        public void GetClientTest()
        {
            var manager = new DbManager();

            manager.AddClient("nsli", "name", "surname", "licNo", 50);

            Client client1 = manager.GetClient("nsli");
            var client2 = new Client("name", "surname", "licNo", 50);

            manager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        public void GetClientNameSurnameTest()
        {
            var manager = new DbManager();
       
            manager.AddClient("nsli", "name", "surname", "licNo", 50);

            Client client1 = manager.GetClient("name", "surname");
            var client2 = new Client("name", "surname", "licNo", 50);

            manager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        // update client info in database
        [Test]
        public void UpdateClientTest()
        {
            var manager = new DbManager();
            manager.AddClient("nsli", "name", "surname", "licNo", 50);

            manager.UpdateClient("nsli", "name1", "surname1", "licNo1", 55);

            var client1 = manager.GetClient("nsli");
            var client2 = new Client("name1", "surname1", "licNo1", 55);

            manager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        [Test]
        public void ClientIfExistsTest()
        {
            var manager = new DbManager();
            bool check1 = manager.ClientIfExists("name", "surname");

            manager.AddClient("nsli", "name", "surname", "licNo", 50);

            bool check = manager.ClientIfExists("name", "surname");
            manager.RemoveClient("nsli");

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

            var manager = new DbManager();

            var beforeAmount = manager.CountAllOrders();
            manager.AddOrder(order);
            var afterAmount = manager.CountAllOrders();

            Assert.Greater(afterAmount, beforeAmount);
        }

        [Test]
        public void RemoveOrderTest()
        {
            var manager = new DbManager();

            var beforeAmount = manager.CountAllOrders();
            manager.RemoveOrder("nste");
            var afterAmount = manager.CountAllOrders();

            Assert.Less(afterAmount, beforeAmount);
        }

        [Test]
        public void GettingOrderTest()
        {
            DbManager manager = new DbManager();

            Car car = new Car();
            Client client = new Client();
            Order order = new Order(car, client, DateTime.Today, DateTime.Today);

            manager.AddCar(car);
            manager.AddClient(client);
            manager.AddOrder(order);

            Order order1 = manager.GetOrder(order.OrderId);

            manager.RemoveOrder(order);
            manager.RemoveClient(client);
            manager.RemoveCar(car);

            Assert.True(order1.Equals(order));
        }

        #endregion

        #region DataLogic

        [Test]
        public void IfNotOccupiedCarCheck()
        {
            DbManager manager = new DbManager();

            Car car = new Car();
            Order order = new Order(car, new Client(), DateTime.Today, DateTime.Today);

            bool checkBefore = manager.IfNotOccupied(car);
            manager.AddOrder(order);
            bool checkAfter = manager.IfNotOccupied(car);

            manager.RemoveOrder(order);
            Assert.False(checkBefore);
            Assert.True(checkAfter);
        }

        [Test]
        public void IfNotOccupiedClientCheck()
        {
            DbManager manager = new DbManager();

            Client client = new Client();
            Order order = new Order(new Car(), client, DateTime.Today, DateTime.Today);

            bool checkBefore = manager.IfNotOccupied(client);
            manager.AddOrder(order);
            bool checkAfter = manager.IfNotOccupied(client);

            manager.RemoveOrder(order);
            Assert.False(checkBefore);
            Assert.True(checkAfter);
        }

        #endregion
    }
}