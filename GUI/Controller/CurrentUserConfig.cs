using DataLayer.Data;
using DataLayer.Database;
using GUI.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    public static class CurrentUserConfig
    {
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        static Client _currentUser;

        static string _id;
        static string _name;
        static string _surname;
        static string _licNo;
        static int _age;

        static CurrentUserConfig()
        {
            _currentUser = new Client();
            _id = _currentUser.Id;
            _name = _currentUser.Name;
            _surname = _currentUser.Surname;
            _licNo = _currentUser.LicNo;
            _age = _currentUser.Age;
        }

        public static Client CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;

                Id = value.Id;
                Name = value.Name;
                Surname = value.Surname;
                LicNo = value.LicNo;
                Age = value.Age;
            }
        }
        public static string Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyStaticPropertyChanged(nameof(Id));
            }
        }
        public static string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyStaticPropertyChanged(nameof(Name));
            }
        }
        public static string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                NotifyStaticPropertyChanged(nameof(Surname));
            }
        }
        public static string LicNo
        {
            get => _licNo;
            set
            {
                _licNo = value;
                NotifyStaticPropertyChanged(nameof(LicNo));
            }
        }
        public static int Age
        {
            get => _age;
            set
            {
                _age = value;
                NotifyStaticPropertyChanged(nameof(Age));
            }
        }
    }
}
