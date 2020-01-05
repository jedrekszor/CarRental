using DataLayer.Data;
using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    public static class CarsConfig
    {
        public static ObservableCollection<Car> _cars;
        public static ObservableCollection<Car> _freeCars;

        static CarsConfig()
        {
            Cars = DatabaseManager.GetCars();
            FreeCars = DatabaseManager.GetAvailableCars();
        }

        public static ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
            }
        }
        public static ObservableCollection<Car> FreeCars
        {
            get => _freeCars;
            set
            {
                _freeCars = value;
            }
        }
    }
}
