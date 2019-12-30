using DataLayer.Data;
using DataLayer.Database;
using System;
using System.Collections.ObjectModel;

namespace DataLayer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ObservableCollection<Car> cars = DatabaseManager.GetCars();
            foreach (Car car in cars)
            {
                Console.WriteLine(car.LicenceNo);
            }
        }
    }
}