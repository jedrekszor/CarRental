using System.ComponentModel;
using DataLayer.Database;

namespace DataLayer.Data
{
    public class Car : INotifyPropertyChanged
    {
        private string _licenceNo;
        private string _brand;
        private string _model;
        private int _mileage;
        private int _passengers;
        private float _price;

        //private readonly DbManager manager = new DbManager();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string LicenceNo
        {
            get => _licenceNo;
        }

        public string Brand
        {
            get => _brand;
        }

        public string Model
        {
            get => _model;
        }

        public int Mileage
        {
            get => _mileage;
            set
            {
                _mileage = value;
                OnPropertyChanged(nameof(Mileage));
                //manager.UpdateCar(_licenceNo, _brand, _model, value, _passengers, _price);
            }
        }

        public int Passengers
        {
            get => _passengers;
        }

        public float Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
                //manager.UpdateCar(_licenceNo, _brand, _model, _mileage, _passengers, value);
            }
        }

        public Car()
        {
            _licenceNo = "car_LicenceNo";
            _brand = "car_brand";
            _model = "car_model";
            _mileage = 0;
            _passengers = 0;
            _price = 0;
        }

        public Car(string licenceNo, string brand, string model, int mileage, int passengers, float price)
        {
            _licenceNo = licenceNo;
            _brand = brand;
            _model = model;
            _mileage = mileage;
            _passengers = passengers;
            _price = price;
        }

        public override string ToString()
        {
            return "\nLicenceNo: " + _licenceNo +
                   "\nBrand: " + _brand +
                   "\nModel: " + _model +
                   "\nMileage: " + _mileage +
                   "\nPassengers: " + _passengers +
                   "\nPrice: " + _price;
        }

        public bool Equals(Car other)
        {
            if (other == null)
            {
                return false;
            }

            return _licenceNo == other._licenceNo && _brand == other._brand && _model == other._model &&
                   _mileage == other._mileage && _passengers == other._passengers && _price == other._price;
        }
    }
}