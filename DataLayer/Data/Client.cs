using System;
using System.ComponentModel;

namespace DataLayer.Data
{
    public class Client : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _surname;
        private string _licNo;
        private int _age;
            
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));

            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string LicNo
        {
            get => _licNo;
            set
            {
                _licNo = value;
                OnPropertyChanged(nameof(LicNo));
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public Client()
        {
            _name = "client_name";
            _surname = "client_surname";
            _licNo = "client_licNo";
            _age = 0;
            _id = GeneratedId();
        }

        public Client(string name, string surname, string licNo, int age)
        {
            _name = name;
            _surname = surname;
            _licNo = licNo;
            _age = age;
            _id = GeneratedId();
        }

        private string GeneratedId()
        {
            OnPropertyChanged(nameof(Id));
            return Convert.ToString(_name[0]) + Convert.ToString(_surname[0]) + Convert.ToString(_licNo[0]) + Convert.ToString(_licNo[1]);
        }

        public override string ToString()
        {
            return "\nid: " + _id +
                   "\nname: " + _name +
                   "\nsurname: " + _surname +
                   "\nlicNo: " + _licNo +
                   "\nage: " + _age;
        }

        public bool Equals(Client other)
        {
            if (other == null)
            {
                return false;
            }

            return _id == other._id && _name == other._name && _surname == other._surname && _licNo == other._licNo && _age == other._age;
        }
    }
}