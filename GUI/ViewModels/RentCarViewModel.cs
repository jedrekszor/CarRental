using DataLayer.Data;
using GUI.Controller;
using GUI.Helper;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModels
{
    class RentCarViewModel : PropertyMonitor
    {
        private string _title;
        private Car _selectedCar;
        private DateTime _pickupDate;
        private DateTime _returnDate;
        private string _alert;
        private ObservableCollection<Car> _freeCars;

        public RentCarViewModel()
        {
            Alert = "";
            Title = "Car rent screen";
            FreeCars = CarsConfig.FreeCars;
            PickupDate = DateTime.Today;
            RetunDate = DateTime.Today;
            Today = DateTime.Today;

            CheckData check = CheckData.GetInstance();
            GoBackCommand = new RelayCommand(o => GoBack(o));
            ConfirmCommand = new RelayCommand(o => Confirm(o), o => check.CheckParametersArray(o));
        }

        public ICommand GoBackCommand { get; }
        public ICommand ConfirmCommand { get; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public ObservableCollection<Car> FreeCars
        {
            get => _freeCars;
            set
            {
                _freeCars = value;
            }
        }

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
            }
        }

        public DateTime PickupDate
        {
            get => _pickupDate;
            set
            {
                _pickupDate = value;
                OnPropertyChanged(nameof(PickupDate));
            }
        }

        public DateTime RetunDate
        {
            get => _returnDate;
            set
            {
                _returnDate = value;
                OnPropertyChanged(nameof(RetunDate));
            }
        }

        public string Alert
        {
            get => _alert;
            set
            {
                _alert = value;
                OnPropertyChanged(nameof(Alert));
            }
        }

        public DateTime Today { get; }

        private void GoBack(object o)
        {
            Mediator.NotifyColleagues("toHome", true);
        }

        private void Confirm(object o)
        {
            Alert = "";
            var values = (object[])o;
            if (CheckData.CheckObjectArray(values))
            {
                if (CheckData.CheckDates(PickupDate, RetunDate))
                {
                    //add new order + check if it is good
                    OrderConfig.CurrOrder = new Order(SelectedCar, CurrentUserConfig.CurrentUser, PickupDate, RetunDate);
                    Mediator.NotifyColleagues("toHome", true);
                }
                else
                {
                    Alert = "Return date must be at least a the same day as pickup date";
                }
            }
        }
    }
}
