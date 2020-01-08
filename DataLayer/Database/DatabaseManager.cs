using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DataLayer.Data;
using System.Collections.ObjectModel;

namespace DataLayer.Database
{
    public static class DatabaseManager
    {
        static private SqlConnection connection;

        //establishing connection
        static DatabaseManager()
        {
            try
            {
                connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=CarRentalDatabase;Integrated Security=True");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #region Car

        #region Adding
        public static void AddCar(string licenceNo, string brand, string model, int mileage, int passengers,
            float price)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO cars(licenceNo, brand, model, mileage, passengers, price) VALUES(@licenceNo, @brand, @model, @mileage, @passengers, @price)";

                command.Parameters.AddWithValue("@licenceNo", licenceNo);
                command.Parameters.AddWithValue("@brand", brand);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@mileage", mileage);
                command.Parameters.AddWithValue("@passengers", passengers);
                command.Parameters.AddWithValue("@price", price);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        public static void AddCar(Car car)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO cars(licenceNo, brand, model, mileage, passengers, price) VALUES(@licenceNo, @brand, @model, @mileage, @passengers, @price)";

                command.Parameters.AddWithValue("@licenceNo", car.LicenceNo);
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@mileage", car.Mileage);
                command.Parameters.AddWithValue("@passengers", car.Passengers);
                command.Parameters.AddWithValue("@price", car.Price);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }
        #endregion

        #region Removing

        public static void RemoveCar(string licenceNo)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM cars WHERE licenceNo = @licenceNo";

                command.Parameters.AddWithValue("@licenceNo", licenceNo);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }


        public static void RemoveCar(Car car)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM cars WHERE licenceNo = @licenceNo";

                command.Parameters.AddWithValue("@licenceNo", car.LicenceNo);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        #endregion

        #region Updating

        public static void UpdateCar(string oldLicenceNo, string newBrand, string newModel, int newMileage, int newPassengers, float newPrice)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE cars SET brand = @newBrand, model = @newModel, mileage = @newMileage, passengers = @newPassengers, price = @newPrice WHERE licenceNo = @oldLicenceNo";

                command.Parameters.AddWithValue("@oldLicenceNo", oldLicenceNo);
                command.Parameters.AddWithValue("@newBrand", newBrand);
                command.Parameters.AddWithValue("@newModel", newModel);
                command.Parameters.AddWithValue("@newMileage", newMileage);
                command.Parameters.AddWithValue("@newPassengers", newPassengers);
                command.Parameters.AddWithValue("@newPrice", newPrice);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        #endregion

        #region Counting

        public static int CountAllCars()
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select count(*) from cars";

                command.ExecuteNonQuery();
                int result = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return result;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return 0;
            }
        }

        #endregion

        #region Getting

        public static Car GetCar(string licenceNo)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from cars where licenceNo = @licenceNo";

                command.Parameters.AddWithValue("@licenceNo", licenceNo);

                Car car = null;

                var r = command.ExecuteReader();

                while (r.Read())
                {
                    car = new Car(Convert.ToString(r["licenceNo"]),
                        Convert.ToString(r["brand"]),
                        Convert.ToString(r["model"]),
                        Convert.ToInt32(r["mileage"]),
                        Convert.ToInt32(r["passengers"]),
                        Convert.ToSingle(r["price"]));
                }

                connection.Close();
                return car;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return null;
            }
        }
        public static ObservableCollection<Car> GetCars()
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from cars";
                SqlDataReader reader = command.ExecuteReader();

                ObservableCollection<Car> cars = new ObservableCollection<Car>();
                Car car = null;

                while (reader.Read())
                {
                    car = new Car(Convert.ToString(reader["licenceNo"]),
                    Convert.ToString(reader["brand"]),
                    Convert.ToString(reader["model"]),
                    Convert.ToInt32(reader["mileage"]),
                    Convert.ToInt32(reader["passengers"]),
                    Convert.ToInt32(reader["price"]));

                    cars.Add(car);
                }
                reader.Close();
                connection.Close();

                return cars;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return new ObservableCollection<Car>();
            }
        }

        public static ObservableCollection<Car> GetAvailableCars()
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from cars where licenceNo not in (select carId from orders)";
                SqlDataReader reader = command.ExecuteReader();

                ObservableCollection<Car> cars = new ObservableCollection<Car>();
                Car car = null;

                while (reader.Read())
                {
                    car = new Car(Convert.ToString(reader["licenceNo"]),
                    Convert.ToString(reader["brand"]),
                    Convert.ToString(reader["model"]),
                    Convert.ToInt32(reader["mileage"]),
                    Convert.ToInt32(reader["passengers"]),
                    Convert.ToInt32(reader["price"]));

                    cars.Add(car);
                }
                reader.Close();
                connection.Close();

                return cars;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return new ObservableCollection<Car>();
            }
        }

        #endregion

        #endregion

        #region Client

        #region Adding
        public static void AddClient(Client client)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO clients(clientId, name, surname, licNo, age) VALUES(@clientId, @name, @surname, @licNo, @age)";

                command.Parameters.AddWithValue("@clientId", client.Id.ToUpper());
                command.Parameters.AddWithValue("@name", client.Name);
                command.Parameters.AddWithValue("@surname", client.Surname);
                command.Parameters.AddWithValue("@licNo", client.LicNo);
                command.Parameters.AddWithValue("@age", client.Age);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }
        public static void AddClient(string id, string name, string surname, string licNo, int age)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO clients(clientId, name, surname, licNo, age) VALUES(@clientId, @name, @surname, @licNo, @age)";

                command.Parameters.AddWithValue("@clientId", id.ToUpper());
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.Parameters.AddWithValue("@licNo", licNo);
                command.Parameters.AddWithValue("@age", age);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }
        #endregion

        #region Removing

        public static void RemoveClient(string clientId)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM clients WHERE clientId = @clientId";

                command.Parameters.AddWithValue("@clientId", clientId);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        public static void RemoveClient(Client client)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM clients WHERE clientId = @clientId";

                command.Parameters.AddWithValue("@clientId", client.Id);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        #endregion

        #region Updating
        public static void UpdateClient(Client client)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE clients SET name = @name, surname = @surname, licNo = @licNo, age = @age WHERE clientId = @clientId";

                command.Parameters.AddWithValue("@clientId", client.Id.ToUpper());
                command.Parameters.AddWithValue("@name", client.Name);
                command.Parameters.AddWithValue("@surname", client.Surname);
                command.Parameters.AddWithValue("@licNo", client.LicNo);
                command.Parameters.AddWithValue("@age", client.Age);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }
        public static void UpdateClient(string clientId, string name, string surname, string licNo, int age)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE clients SET name = @name, surname = @surname, licNo = @licNo, age = @age WHERE clientId = @clientId";

                command.Parameters.AddWithValue("@clientId", clientId.ToUpper());
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@surname", surname);
                command.Parameters.AddWithValue("@licNo", licNo);
                command.Parameters.AddWithValue("@age", age);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }
        #endregion

        #region Counting
        public static int CountAllClients()
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select count(*) from clients";

                command.ExecuteNonQuery();
                int result = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return result;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return 0;
            }
        }
        #endregion

        #region Getting
        public static Client GetClient(Client _client)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM clients WHERE clientId = @clientId";
                command.Parameters.AddWithValue("@clientId", _client.Id);

                Client client = null;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    client = new Client(
                   Convert.ToString(reader["name"]),
                   Convert.ToString(reader["surname"]),
                   Convert.ToString(reader["licNo"]),
                   Convert.ToInt32(reader["age"]));
                }
                reader.Close();
                connection.Close();

                return client;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return new Client();
            }
        }
        public static Client GetClient(string name, string surname)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM clients WHERE name = @v_name and surname = @v_surname";
                command.Parameters.AddWithValue("@v_name", name);
                command.Parameters.AddWithValue("@v_surname", surname);

                Client client = null;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    client = new Client(
                   Convert.ToString(reader["name"]),
                   Convert.ToString(reader["surname"]),
                   Convert.ToString(reader["licNo"]),
                   Convert.ToInt32(reader["age"]));
                }
                reader.Close();
                connection.Close();

                return client;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return new Client();
            }
        }

        public static Client GetClient(string clientId)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM clients WHERE clientId = @clientId";
                command.Parameters.AddWithValue("@clientId", clientId);

                Client client = null;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    client = new Client(
                        Convert.ToString(reader["name"]),
                        Convert.ToString(reader["surname"]),
                        Convert.ToString(reader["licNo"]),
                        Convert.ToInt32(reader["age"]));
                }
                reader.Close();
                connection.Close();

                return client;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return new Client();
            }
        }
        #endregion

        #endregion

        #region Order

        #region Adding

        public static void AddOrder(Order order)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO orders(orderId, clientId, carId, price, rentDate, returnDate) VALUES(@orderId, @clientId, @carId, @price, @rentDate, @returnDate)";

                command.Parameters.AddWithValue("@orderId", order.OrderId);
                command.Parameters.AddWithValue("@clientId", order.Client.Id);
                command.Parameters.AddWithValue("@carId", order.Car.LicenceNo);
                command.Parameters.AddWithValue("@price", order.Car.Price);
                command.Parameters.AddWithValue("@rentDate", order.RentDate);
                command.Parameters.AddWithValue("@returnDate", order.ReturnDate);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        #endregion

        #region Removing

        public static void RemoveOrder(string orderId)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM orders WHERE orderId = @orderId";
                command.Parameters.AddWithValue("@orderId", orderId);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        public static void RemoveOrder(Order order)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM orders WHERE orderId = @orderId";
                command.Parameters.AddWithValue("@orderId", order.OrderId);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        public static Order GetOrder(string name, string surname)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select o.* from orders o inner join clients c on o.clientId = c.clientId where c.name = @v_name and c.surname = @v_surname";
                command.Parameters.AddWithValue("@v_name", name);
                command.Parameters.AddWithValue("@v_surname", surname);

                string licenceNo = null;
                string orderId = null;
                string clientId = null;
                DateTime rentDate = new DateTime();
                DateTime returnDate = new DateTime();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orderId = (string)reader["orderId"];
                    clientId = (string)reader["clientId"];
                    licenceNo = (string)reader["carId"];
                    rentDate = (DateTime)reader["rentDate"];
                    returnDate = (DateTime)reader["returnDate"];
                }
                reader.Close();
                connection.Close();

                Car car = GetCar(licenceNo);
                Client client = GetClient(clientId);

                if(car is null && client is null)
                {
                    return null;
                }
                else
                {
                    return new Order(car, client, rentDate, returnDate);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return new Order();
            }
        }

        #endregion

        #region Counting

        public static int CountAllOrders()
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select count(*) from orders";

                command.ExecuteNonQuery();
                int result = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return result;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return 0;
            }
        }

        #endregion

        #region Getting

        public static Order GetOrder(string orderId)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from orders where orderId = @orderId";

                command.Parameters.AddWithValue("@orderId", orderId);

                var carId = "";
                var clientId = "";
                DateTime rentDate = new DateTime();
                DateTime returnDate = new DateTime();

                var r = command.ExecuteReader();

                while (r.Read())
                {
                    carId = Convert.ToString(r["carId"]);
                    clientId = Convert.ToString(r["clientId"]);
                    rentDate = Convert.ToDateTime(r["rentDate"].ToString());
                    returnDate = Convert.ToDateTime(r["returnDate"].ToString());
                }

                connection.Close();
                Car car = GetCar(carId);
                Client client = GetClient(clientId);

                if(car == null || client == null)
                {
                    return null;
                }
                else
                {
                    return new Order(car, client, rentDate, returnDate);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return null;
            }
        }

        #endregion

        #region Updating

        public static void UpdateOrder(string orderId, DateTime rentDate, DateTime returnDate, float price)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE orders SET rentDate = @v_rentDate, returnDate = @v_returnDate, price = @v_price WHERE orderId = @v_orderId";

                command.Parameters.AddWithValue("@v_orderId", orderId);
                command.Parameters.AddWithValue("@v_rentDate", rentDate);
                command.Parameters.AddWithValue("@v_returnDate", returnDate);
                command.Parameters.AddWithValue("@v_price", price);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        #endregion

        #region Archiving

        public static void ArchiveOrder(Order order, int distance, double finalPrice, string feedback)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO orders_history(orderId, clientId, carId, rentDate, returnDate, distance, finalPrice, feedback) VALUES(@orderId, @clientId, @carId, @rentDate, @returnDate, @distance, @finalPrice, @feedback)";

                command.Parameters.AddWithValue("@orderId", order.OrderId);
                command.Parameters.AddWithValue("@clientId", order.Client.Id);
                command.Parameters.AddWithValue("@carId", order.Car.LicenceNo);
                command.Parameters.AddWithValue("@rentDate", order.RentDate);
                command.Parameters.AddWithValue("@returnDate", order.ReturnDate);
                command.Parameters.AddWithValue("@distance", distance);
                command.Parameters.AddWithValue("@finalPrice", finalPrice);
                command.Parameters.AddWithValue("@feedback", feedback);

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
            }
        }

        #endregion

        #endregion

        #region dataLogic
        public static bool IfClientExists(string name, string surname)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from clients where name = @v_name and surname = @v_surname";
                command.Parameters.AddWithValue("@v_name", name);
                command.Parameters.AddWithValue("@v_surname", surname);

                bool check = false;

                SqlDataReader reader = command.ExecuteReader();
    
                check = reader.HasRows;
                reader.Close();
                connection.Close();
                return check;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return false;
            }
        }

        public static bool IfClientAttachedToOrder(string name, string surname)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from orders o inner join clients c on o.clientId = c.clientId where c.name = @v_name and c.surname = @v_surname";
                command.Parameters.AddWithValue("@v_name", name);
                command.Parameters.AddWithValue("@v_surname", surname);

                bool check = false;

                SqlDataReader reader = command.ExecuteReader();

                check = reader.HasRows;
                reader.Close();
                connection.Close();
                return check;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return false;
            }
        }

        public static bool IfNotOccupied(Car car)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from orders where carId = @v_carId";
                command.Parameters.AddWithValue("@v_carId", car.LicenceNo.ToUpper());

                var reader = command.ExecuteReader();
                bool check = reader.HasRows;

                reader.Close();
                connection.Close();
                return check;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return false;
            }
        }

        public static bool IfNotOccupied(Client client)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from orders where exists (select * from orders where clientId = @v_clientId)";
                command.Parameters.AddWithValue("@v_clientId", client.Id.ToUpper());

                var r = command.ExecuteReader();

                bool check = r.HasRows;

                connection.Close();
                return check;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                connection.Close();
                return false;
            }
        }


        #endregion
    }
}
