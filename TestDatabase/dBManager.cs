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
//            DbManager manager = new DbManager();

            var amountBefore = DbManager.CountAllCars();
            DbManager.AddCar("test", "brand", "model", 100, 4, 10);
            var amountAfter = DbManager.CountAllCars();

            Assert.Greater(amountAfter, amountBefore);
            DbManager.RemoveCar("test");
        }

        // adding car with given object
        [Test]
        public void AddingCarObjTest()
        {
            //DbManager manager = new DbManager();

            var amountBefore = DbManager.CountAllCars();
            DbManager.AddCar(new Car("test", "brand", "model", 100, 4, 10));
            var amountAfter = DbManager.CountAllCars();

            Assert.Greater(amountAfter, amountBefore);
            DbManager.RemoveCar("test");
        }

        // removing car with given parameters
        [Test]
        public void RemovingCarTest()
        {
            //DbManager manager = new DbManager();
            DbManager.AddCar(new Car("test", "brand", "model", 100, 4, 10));

            var amountBefore = DbManager.CountAllCars();
            DbManager.RemoveCar("test");
            var amountAfter = DbManager.CountAllCars();

            Assert.Less(amountAfter, amountBefore);
        }

        // getting car form database
        [Test]
        public void GetCarTest()
        {
            //var manager = new DbManager();
            DbManager.AddCar("testAdd", "brand", "model", 1000, 5, 10);

            var car1 = DbManager.GetCar("testAdd");
            var car2 = new Car("testAdd", "brand", "model", 1000, 5, 10);

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());

            DbManager.RemoveCar("testAdd");

            Assert.True(car1.Equals(car2));
        }

        // updating car info in database
        [Test]
        public void UpdateCarTest()
        {
            //var manager = new DbManager();
            DbManager.AddCar("test", "brand", "model", 100, 4, 10);
            DbManager.UpdateCar("test", "brand1", "model1", 110, 5, 11);

            var car1 = DbManager.GetCar("test");
            var car2 = new Car("test", "brand1", "model1", 110, 5, 11);

            DbManager.RemoveCar("test");

            Assert.True(car1.Equals(car2));
        }

        #endregion

        //        ---------------------------------------------------------------------------------------------

        #region ClientTests

        // Adding client with parameters
        [Test]
        public void AddingClientTest()
        {
//            DbManager manager = new DbManager();

            var amountBefore = DbManager.CountAllClients();
            DbManager.AddClient("nsli", "name", "surname", "licNo", 25);
            var amountAfter = DbManager.CountAllClients();

            Assert.Greater(amountAfter, amountBefore);
            DbManager.RemoveClient("nsli");
        }

        // Adding client with object
        [Test]
        public void AddingClientObjTest()
        {
//            DbManager manager = new DbManager();
            var client = new Client();

            var amountBefore = DbManager.CountAllClients();
            DbManager.AddClient(client);
            var amountAfter = DbManager.CountAllClients();

            DbManager.RemoveClient(client.Id);
            Assert.Greater(amountAfter, amountBefore);
        }

        // removing client with given parameters
        [Test]
        public void RemovingClientTest()
        {
//            DbManager manager = new DbManager();
            var client = new Client();
            DbManager.AddClient(client);

            var amountBefore = DbManager.CountAllClients();
            DbManager.RemoveClient(client.Id);
            var amountAfter = DbManager.CountAllClients();

            Assert.Less(amountAfter, amountBefore);
        }

        // removing client with given object
        [Test]
        public void RemovingClientObjTest()
        {
//            DbManager manager = new DbManager();
            var client = new Client();

            DbManager.AddClient(client);

            var amountBefore = DbManager.CountAllClients();
            DbManager.RemoveClient(client.Id);
            var amountAfter = DbManager.CountAllClients();

            Assert.Less(amountAfter, amountBefore);
        }

        // get client as object form database
        [Test]
        public void GetClientTest()
        {
//            var manager = new DbManager();

            DbManager.AddClient("nsli", "name", "surname", "licNo", 50);

            Client client1 = DbManager.GetClient("nsli");
            var client2 = new Client("name", "surname", "licNo", 50);

            DbManager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        public void GetClientNameSurnameTest()
        {
//            var manager = new DbManager();
       
            DbManager.AddClient("nsli", "name", "surname", "licNo", 50);

            Client client1 = DbManager.GetClient("name", "surname");
            var client2 = new Client("name", "surname", "licNo", 50);

            DbManager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        // update client info in database
        [Test]
        public void UpdateClientTest()
        {
//            var manager = new DbManager();
            DbManager.AddClient("nsli", "name", "surname", "licNo", 50);

            DbManager.UpdateClient("nsli", "name1", "surname1", "licNo1", 55);

            var client1 = DbManager.GetClient("nsli");
            var client2 = new Client("name1", "surname1", "licNo1", 55);

            DbManager.RemoveClient("nsli");

            Assert.True(client1.Equals(client2));
        }

        [Test]
        public void ClientIfExistsTest()
        {
//            var manager = new DbManager();
            bool check1 = DbManager.ClientIfExists("name", "surname");

            DbManager.AddClient("nsli", "name", "surname", "licNo", 50);

            bool check = DbManager.ClientIfExists("name", "surname");
            DbManager.RemoveClient("nsli");

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

//            var manager = new DbManager();

            var beforeAmount = DbManager.CountAllOrders();
            DbManager.AddOrder(order);
            var afterAmount = DbManager.CountAllOrders();

            Assert.Greater(afterAmount, beforeAmount);
        }

        [Test]
        public void RemoveOrderTest()
        {
//            var manager = new DbManager();

            var beforeAmount = DbManager.CountAllOrders();
            DbManager.RemoveOrder("nste");
            var afterAmount = DbManager.CountAllOrders();

            Assert.Less(afterAmount, beforeAmount);
        }

        [Test]
        public void GettingOrderTest()
        {
//            DbManager manager = new DbManager();

            Car car = new Car();
            Client client = new Client();
            Order order = new Order(car, client, DateTime.Today, DateTime.Today);

            DbManager.AddCar(car);
            DbManager.AddClient(client);
            DbManager.AddOrder(order);

            Order order1 = DbManager.GetOrder(order.OrderId);

            DbManager.RemoveOrder(order);
            DbManager.RemoveClient(client);
            DbManager.RemoveCar(car);

            Assert.True(order1.Equals(order));
        }

        #endregion

        #region DataLogic

        [Test]
        public void IfNotOccupiedCarCheck()
        {
//            DbManager manager = new DbManager();

            Car car = new Car();
            Order order = new Order(car, new Client(), DateTime.Today, DateTime.Today);

            bool checkBefore = DbManager.IfNotOccupied(car);
            DbManager.AddOrder(order);
            bool checkAfter = DbManager.IfNotOccupied(car);

            DbManager.RemoveOrder(order);
            Assert.False(checkBefore);
            Assert.True(checkAfter);
        }

        [Test]
        public void IfNotOccupiedClientCheck()
        {
//            DbManager manager = new DbManager();

            Client client = new Client();
            Order order = new Order(new Car(), client, DateTime.Today, DateTime.Today);

            bool checkBefore = DbManager.IfNotOccupied(client);
            DbManager.AddOrder(order);
            bool checkAfter = DbManager.IfNotOccupied(client);

            DbManager.RemoveOrder(order);
            Assert.False(checkBefore);
            Assert.True(checkAfter);
        }

        #endregion
    }
}