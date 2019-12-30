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

        //Create tables też można dodać jakby coś sie wysypało


        #region Cars

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

        #endregion

        #region Clients

        //CREATE
        public static void AddClient(Client client)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO clients('clientId', 'name', 'surname', 'licNo', 'age') VALUES(@clientId, @name, @surname, @licNo, @age)";

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
                command.CommandText = "INSERT INTO clients('clientId', 'name', 'surname', 'licNo', 'age') VALUES(@clientId, @name, @surname, @licNo, @age)";

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

        //READ
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

        //UPDATE
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
                command.Parameters.AddWithValue("@licNo", surname);
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

        //DELETE

        //LOGIC
        public static bool IfClientExists(string name, string surname)
        {
            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from clients where exists (select * from clients where name = @v_name and surname = @v_surname)";
                command.Parameters.AddWithValue("@v_name", name);
                command.Parameters.AddWithValue("@v_surname", surname);

                bool check = false;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    check = reader.HasRows;
                }
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

        #endregion

    }
}
