using DataLayer.Data;
using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    public static class CarsListConfig
    {
//        public static DbManager _manager = new DbManager();
        public static List<Car> _allCars;

        static CarsListConfig()
        {
            _allCars = DbManager.GetAllCars();
        }

        //public static List<Car> AllCars
        //{
        //    get => _allCars;
        //    set
        //    {
        //        _allCars = value;
        //    }
        //}
    }
}
