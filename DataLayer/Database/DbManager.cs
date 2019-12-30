using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataLayer.Data;


namespace DataLayer.Database
{
     public class DbManager
    {
        private readonly SQLiteConnection _myConnection;

        private readonly string dbFile = "database.db";
        private readonly string path = @".\database.db";

        #region Constructors

        public DbManager()
        {
            _myConnection = new SQLiteConnection("Data Source=" + path);
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
            }
            CreateTables();
        }

        public DbManager(string path)
        {
            _myConnection = new SQLiteConnection("Data Source=" + path + dbFile);
            if (!File.Exists(path + dbFile))
            {
                SQLiteConnection.CreateFile(path + dbFile);
            }
            CreateTables();
        }

        #endregion

        #region ConnectionsAndSetUp

        private void OpenConnection()
        {
            if (_myConnection.State != System.Data.ConnectionState.Open)
            {
                _myConnection.Open();
            }
        }

        private void CloseConnection()
        {
            if (_myConnection.State != System.Data.ConnectionState.Closed)
            {
                _myConnection.Close();
            }
        }

        //setting up the tables initially
        private void CreateTables()
        {
            const string createCars = "CREATE TABLE IF NOT EXISTS cars(licenceNo varchar(255), brand varchar(255), model varchar(255), mileage integer, passengers integer, price float, primary key(licenceNo))";
            var makeCars = new SQLiteCommand(createCars, _myConnection);

            const string createClients = "CREATE TABLE IF NOT EXISTS clients(clientId varchar(255), name varchar(255), surname varchar(255), licNo varchar(255), age integer, primary key(clientId))";
            var makeClients = new SQLiteCommand(createClients, _myConnection);

            const string createOrders =
                "CREATE TABLE IF NOT EXISTS orders(orderId varchar(255), clientId varchar(255), carId varchar(255), price float, rentDate string, returnDate string, primary key(orderId), foreign key (clientId) references clients(clientId), foreign key (carId) references cars(licenceNo))";
            var makeOrders = new SQLiteCommand(createOrders, _myConnection);

            OpenConnection();
            makeCars.ExecuteNonQuery();
            makeClients.ExecuteNonQuery();
            makeOrders.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Car

        #region Adding

        //Adding car into database with given parameters
        public void AddCar(string licenceNo, string brand, string model, int mileage, int passengers, float price)
        {
            const string query = "INSERT INTO cars('licenceNo', 'brand', 'model', 'mileage', 'passengers', 'price') VALUES(@licenceNo, @brand, @model, @mileage, @passengers, @price)";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@licenceNo", licenceNo);
            myCommand.Parameters.AddWithValue("@brand", brand);
            myCommand.Parameters.AddWithValue("@model", model);
            myCommand.Parameters.AddWithValue("@mileage", mileage);
            myCommand.Parameters.AddWithValue("@passengers", passengers);
            myCommand.Parameters.AddWithValue("@price", price);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        //Adding car into database with given object
        public void AddCar(Car car)
        {
            const string query = "INSERT INTO cars('licenceNo', 'brand', 'model', 'mileage', 'passengers', 'price') VALUES(@licenceNo, @brand, @model, @mileage, @passengers, @price)";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@licenceNo", car.LicenceNo);
            myCommand.Parameters.AddWithValue("@brand", car.Brand);
            myCommand.Parameters.AddWithValue("@model", car.Model);
            myCommand.Parameters.AddWithValue("@mileage", car.Mileage);
            myCommand.Parameters.AddWithValue("@passengers", car.Passengers);
            myCommand.Parameters.AddWithValue("@price", car.Price);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Removing

        //Removing car from database with given parameters
        public void RemoveCar(string licenceNo)
        {
            const string query = "DELETE FROM cars WHERE licenceNo = @licenceNo";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@licenceNo", licenceNo);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        //Removing car from database with given object
        public void RemoveCar(Car car)
        {
            const string query = "DELETE FROM cars WHERE licenceNo = @licenceNo";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@licenceNo", car.LicenceNo);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Updating

        public void UpdateCar(string oldLicenceNo, string newBrand, string newModel, int newMileage, int newPassengers, float newPrice)
        {
            const string query = "UPDATE cars SET brand = @newBrand, model = @newModel, mileage = @newMileage, passengers = @newPassengers, price = @newPrice WHERE licenceNo = @oldLicenceNo";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@oldLicenceNo", oldLicenceNo);
            myCommand.Parameters.AddWithValue("@newBrand", newBrand);
            myCommand.Parameters.AddWithValue("@newModel", newModel);
            myCommand.Parameters.AddWithValue("@newMileage", newMileage);
            myCommand.Parameters.AddWithValue("@newPassengers", newPassengers);
            myCommand.Parameters.AddWithValue("@newPrice", newPrice);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Counting

        public int CountAllCars()
        {
            const string query = "select count(*) from cars";
            var myCommand = new SQLiteCommand(query, _myConnection);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            int result = Convert.ToInt32(myCommand.ExecuteScalar());
            CloseConnection();
            //Console.WriteLine(result);
            return result;
        }

        #endregion

        #region Getting

        public Car GetCar(string licenceNo)
        {
            const string query = "select * from cars where licenceNo = @licenceNo";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@licenceNo", licenceNo);

            Car car = null;

            OpenConnection();
            var r = myCommand.ExecuteReader();

            while (r.Read())
            {
                car = new Car(Convert.ToString(r["licenceNo"]),
                    Convert.ToString(r["brand"]),
                    Convert.ToString(r["model"]),
                    Convert.ToInt32(r["mileage"]),
                    Convert.ToInt32(r["passengers"]),
                    Convert.ToSingle(r["price"]));
            }
            CloseConnection();

            return car;
        }

        public List<Car> GetAllCars()
        {
            var cars = new List<Car>();
            const string query = "select * from cars";
            var myCommand = new SQLiteCommand(query, _myConnection);

            Car car = null;

            OpenConnection();
            var r = myCommand.ExecuteReader();

            while (r.Read())
            {
                car = new Car(Convert.ToString(r["licenceNo"]),
                    Convert.ToString(r["brand"]),
                    Convert.ToString(r["model"]),
                    Convert.ToInt32(r["mileage"]),
                    Convert.ToInt32(r["passengers"]),
                    Convert.ToInt32(r["price"]));

                cars.Add(car);
            }
            CloseConnection();

            return cars;
        }

        #endregion

        #endregion

        #region Client

        #region Adding

        //adding client with given parameters
        public void AddClient(string id, string name, string surname, string licNo, int age)
        {
            const string query = "INSERT INTO clients('clientId', 'name', 'surname', 'licNo', 'age') VALUES(@clientId, @name, @surname, @licNo, @age)";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@clientId", id);
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@surname", surname);
            myCommand.Parameters.AddWithValue("@licNo", licNo);
            myCommand.Parameters.AddWithValue("@age", age);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        //adding client with given object
        public void AddClient(Client client)
        {
            const string query = "INSERT INTO clients('clientId', 'name', 'surname', 'licNo', 'age') VALUES(@clientId, @name, @surname, @licNo, @age)";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@clientId", client.Id);
            myCommand.Parameters.AddWithValue("@name", client.Name);
            myCommand.Parameters.AddWithValue("@surname", client.Surname);
            myCommand.Parameters.AddWithValue("@licNo", client.LicNo);
            myCommand.Parameters.AddWithValue("@age", client.Age);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Removing

        //removing client form database with given parameter: clientId
        public void RemoveClient(string clientId)
        {
            const string query = "DELETE FROM clients WHERE clientId = @clientId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@clientId", clientId);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        //removing client form database with given object
        public void RemoveClient(Client client)
        {
            const string query = "DELETE FROM clients WHERE clientId = @clientId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@clientId", client.Id);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Updating

        public void UpdateClient(Client client)
        {
            const string query = "UPDATE clients SET name = @name, surname = @surname, licNo = @licNo, age = @age WHERE clientId = @clientId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@clientId", client.Id.ToUpper());
            myCommand.Parameters.AddWithValue("@name", client.Name);
            myCommand.Parameters.AddWithValue("@surname", client.Surname);
            myCommand.Parameters.AddWithValue("@licNo", client.LicNo);
            myCommand.Parameters.AddWithValue("@age", client.Age);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public void UpdateClient(string clientId, string name, string surname, string licNo, int age)
        {
            clientId = clientId.ToUpper();
            const string query = "UPDATE clients SET name = @name, surname = @surname, licNo = @licNo, age = @age WHERE clientId = @clientId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@clientId", clientId);
            myCommand.Parameters.AddWithValue("@name", name);
            myCommand.Parameters.AddWithValue("@surname", surname);
            myCommand.Parameters.AddWithValue("@licNo", licNo);
            myCommand.Parameters.AddWithValue("@age", age);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Counting

        public int CountAllClients()
        {
            const string query = "select count(*) from clients";
            var myCommand = new SQLiteCommand(query, _myConnection);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            int result = Convert.ToInt32(myCommand.ExecuteScalar());
            CloseConnection();
            return result;
        }

        #endregion

        #region Getting

        public Client GetClient(string clientId)
        {
            clientId = clientId.ToUpper();
            const string query = "select * from clients where clientId = @clientId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@clientId", clientId);

            Client client = null;

            OpenConnection();
            var r = myCommand.ExecuteReader();

            while (r.Read())
            {
                client = new Client(
                    Convert.ToString(r["name"]),
                    Convert.ToString(r["surname"]),
                    Convert.ToString(r["licNo"]),
                    Convert.ToInt32(r["age"]));
            }
            CloseConnection();

            return client;
        }

        public Client GetClient(string name, string surname)
        {
            const string query = "select * from clients where name = @v_name and surname = @v_surname";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@v_name", name);
            myCommand.Parameters.AddWithValue("@v_surname", surname);

            Client client = null;

            OpenConnection();
            var r = myCommand.ExecuteReader();

            while (r.Read())
            {
                client = new Client(
                    Convert.ToString(r["name"]),
                    Convert.ToString(r["surname"]),
                    Convert.ToString(r["licNo"]),
                    Convert.ToInt32(r["age"]));
            }
            CloseConnection();

            return client;
        }

        public bool ClientIfExists(string name, string surname)
        {
            const string query = "select * from clients where exists (select * from clients where name = @v_name and surname = @v_surname)";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@v_name", name);
            myCommand.Parameters.AddWithValue("@v_surname", surname);

            bool check = false;

            OpenConnection();
            var r = myCommand.ExecuteReader();
            while (r.Read())
            {
                check = r.HasRows;
            }
            CloseConnection();
            return check;
        }

        public bool ClientIfExistsId(Client client)
        {
            const string query = "select * from clients where exists (select * from clients where clientId = @v_clientId)";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@v_clientId", client.Id);

            bool check = false;

            OpenConnection();
            var r = myCommand.ExecuteReader();
            while (r.Read())
            {
                check = r.HasRows;
            }
            CloseConnection();
            return check;
        }

        #endregion

        #endregion

        #region Order

        #region Adding

        public void AddOrder(Order order)
        {
            const string query = "INSERT INTO orders('orderId', 'clientId', 'carId', 'price', 'rentDate', 'returnDate') VALUES(@orderId, @clientId, @carId, @price, @rentDate, @returnDate)";
            var myCommand = new SQLiteCommand(query, _myConnection);

            myCommand.Parameters.AddWithValue("@orderId", order.OrderId);
            myCommand.Parameters.AddWithValue("@clientId", order.Client.Id);
            myCommand.Parameters.AddWithValue("@carId", order.Car.LicenceNo);
            myCommand.Parameters.AddWithValue("@price", order.Car.Price);

            string format = "yyyy-MM-dd HH:mm:ss";

            myCommand.Parameters.AddWithValue("@rentDate", order.RentDate.ToString(format));
            myCommand.Parameters.AddWithValue("@returnDate", order.ReturnDate.ToString(format));

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Removing

        //removing order by given parameter: orderId
        public void RemoveOrder(string orderId)
        {
            const string query = "DELETE FROM orders WHERE orderId = @orderId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@orderId", orderId);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        //removing order by given object
        public void RemoveOrder(Order order)
        {
            const string query = "DELETE FROM orders WHERE orderId = @orderId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@orderId", order.OrderId);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        #endregion

        #region Counting

        public int CountAllOrders()
        {
            const string query = "select count(*) from orders";
            var myCommand = new SQLiteCommand(query, _myConnection);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            int result = Convert.ToInt32(myCommand.ExecuteScalar());
            CloseConnection();
            return result;
        }

        #endregion

        #region Getting

        public Order GetOrder(string orderId)
        {
            const string query = "select * from orders where orderId = @orderId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@orderId", orderId);

            var carId = "";
            var clientId = "";
            DateTime rentDate = new DateTime();
            DateTime returnDate = new DateTime();

            OpenConnection();
            var r = myCommand.ExecuteReader();

            while (r.Read())
            {
                carId = Convert.ToString(r["carId"]);
                clientId = Convert.ToString(r["clientId"]);
                rentDate = Convert.ToDateTime(r["rentDate"].ToString());
                returnDate = Convert.ToDateTime(r["returnDate"].ToString());
            }

            CloseConnection();

            Car car = GetCar(carId);
            Client client = GetClient(clientId);

            return new Order(car, client, rentDate, returnDate);
        }

        #endregion

        #region Updating

        public void UpdateOrder(string orderId, DateTime rentDate, DateTime returnDate, float price)
        {
            const string query = "UPDATE orders SET rentDate = @v_rentDate, returnDate = @v_returnDate, price = @v_price WHERE orderId = @v_orderId";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@v_orderId", orderId);

            string format = "yyyy-MM-dd HH:mm:ss";

            myCommand.Parameters.AddWithValue("@v_rentDate", rentDate.ToString(format));
            myCommand.Parameters.AddWithValue("@v_returnDate", returnDate.ToString(format));

            myCommand.Parameters.AddWithValue("@v_price", price);

            OpenConnection();
            myCommand.ExecuteNonQuery();
            CloseConnection();
        }
    
        #endregion

        #region dataLogic

        public bool IfNotOccupied(Car car)
        {
            const string query = "select * from orders where exists (select * from orders where carId = @v_carId)";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@v_carId", car.LicenceNo);

            bool check = false;

            OpenConnection();
            var r = myCommand.ExecuteReader();
            while (r.Read())
            {
                check = r.HasRows;
            }
            CloseConnection();
            return check;
        }

        public bool IfNotOccupied(Client client)
        {
            const string query = "select * from orders where exists (select * from orders where clientId = @v_clientId)";
            var myCommand = new SQLiteCommand(query, _myConnection);
            myCommand.Parameters.AddWithValue("@v_clientId", client.Id);

            bool check = false;

            OpenConnection();
            var r = myCommand.ExecuteReader();
            while (r.Read())
            {
                check = r.HasRows;
            }
            CloseConnection();
            return check;
        }

        #endregion

        #endregion
    }
}