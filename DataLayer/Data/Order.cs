﻿using System;
using System.ComponentModel;
using DataLayer.Database;

namespace DataLayer.Data
{
    public class Order : INotifyPropertyChanged
    {
<<<<<<< HEAD
=======
        //private DbManager manager = new DbManager();

>>>>>>> f403d439f2162690375ff6a99582a0cd277b622e
        private string _orderId;
        private Car _car;
        private Client _client;
        private DateTime _rentDate;
        private DateTime _returnDate;
        private float _price;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Order()
        {
            _orderId = "unknown";
            _car = new Car();
            _client = new Client();
            _rentDate = new DateTime();
            _returnDate = new DateTime();
            _price = 0;
        }

        public Order(Car car, Client client, DateTime rentDate, DateTime returnDate)
        {
            _car = car;
            _client = client;
            _rentDate = rentDate;
            _returnDate = returnDate;
            _price = car.Price;
            _orderId = GeneratedId();
        }

        public string OrderId
        {
            get => _orderId;
        }

        public Car Car
        {
            get => _car;
        }

        public Client Client
        {
            get => _client;
        }

        public DateTime RentDate
        {
            get => _rentDate;
            set
            {
                _rentDate = value;

                OnPropertyChanged(nameof(RentDate));
<<<<<<< HEAD
                //manager.UpdateOrder(_orderId, value, _returnDate, _price);
=======
                DbManager.UpdateOrder(_orderId, value, _returnDate, _price);
>>>>>>> f403d439f2162690375ff6a99582a0cd277b622e
            }
        }

        public DateTime ReturnDate
        {
            get => _returnDate;
            set
            {
                _returnDate = value;
                OnPropertyChanged(nameof(ReturnDate));
<<<<<<< HEAD
                //manager.UpdateOrder(_orderId, _rentDate, value, _price);
=======
                DbManager.UpdateOrder(_orderId, _rentDate, value, _price);
>>>>>>> f403d439f2162690375ff6a99582a0cd277b622e
            }
        }

        public float Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
<<<<<<< HEAD
                //manager.UpdateOrder(_orderId, _rentDate, _returnDate, value);
=======
                DbManager.UpdateOrder(_orderId, _rentDate, _returnDate, value);
>>>>>>> f403d439f2162690375ff6a99582a0cd277b622e
            }
        }
        private string GeneratedId()
        {
            return Convert.ToString(_client.Name[0]) + Convert.ToString(_client.Surname[0]) +
                   Convert.ToString(_car.LicenceNo[0]) + Convert.ToString(_car.LicenceNo[1]);
        }

        public bool Equals(Order other)
        {
            if (other == null)
            {
                return false;
            }

            return _orderId == other._orderId &&
                   _car.Equals(other._car) &&
                   _client.Equals(other._client) &&
                   _rentDate.Equals(other._rentDate) &&
                   _returnDate.Equals(other._returnDate) &&
                   _price == other._price;
        }

        public override string ToString()
        {
            return "\nOrderId: " + _orderId +
                   "\nCar: " + "\n" + _car.ToString() + "\n" +
                   "\nClient : " + "\n" + _client + "\n" +
                   "\nRentDate: " + _rentDate +
                   "\nReturnDate: " + _returnDate +
                   "\nPrice: " + _price;
        }
    }
}