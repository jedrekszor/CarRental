﻿using DataLayer.Data;
using DataLayer.Database;
using GUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModels
{
    public class CarListViewModel : PropertyMonitor
    {
        private string _title;

        public CarListViewModel()
        {
            Title = "Car list screen";
            GoToHomeCommand = new RelayCommand(o => GoHome(o));
            GoToRentCarCommand = new RelayCommand(o => GoRentCar(o));
        }

        public ICommand GoToHomeCommand { get; }
        public ICommand GoToRentCarCommand { get; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private void GoHome(object o)
        {
            Mediator.NotifyColleagues("toHome", true);
        }
        private void GoRentCar(object o)
        {
            Mediator.NotifyColleagues("toRent", true);
        }
    }
}
