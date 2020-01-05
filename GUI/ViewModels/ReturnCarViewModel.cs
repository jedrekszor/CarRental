using DataLayer.Database;
using GUI.Controller;
using GUI.Helper;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI.ViewModels
{
    public class ReturnCarViewModel : PropertyMonitor
    {
        private string _title;
        private string _alert;
        private DateTime _returnDate;
        private string _feedback;
        private int _distanceDriven;
        private double _finalPrice;
        private ObservableCollection<string> _feedbackOpts;

        public ReturnCarViewModel()
        {
            Title = "Return car screen";
            Alert = "--Alert--";

            CheckData checker = CheckData.GetInstance();
            GoToHomeCommand = new RelayCommand(o => GoHome(o));
            ConfirmCommand = new RelayCommand(o => Confirm(o), o => checker.CheckParametersArray(o));
            ReturnDate = DateTime.Now;
            Today = DateTime.Now;
            FeedbackOpts = new ObservableCollection<string>()
            {
                "meh.",
                "good",
                "very good",
                "nice",
                "excellent"
            };
        }

        public ICommand ConfirmCommand { get; }
        public ICommand GoToHomeCommand { get; }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
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
        public string Feedback
        {
            get => _feedback;
            set
            {
                _feedback = value;
                OnPropertyChanged(nameof(Feedback));
            }
        }
        public double FinalPrice
        {
            get => _finalPrice;
            set
            {
                _finalPrice = value;
                OnPropertyChanged(nameof(FinalPrice));
            }
        }
        public ObservableCollection<string> FeedbackOpts
        {
            get => _feedbackOpts;
            set
            {
                _feedbackOpts = value;
            }
        }

        public DateTime Today { get; set; }

        //! properties updating price
        public DateTime ReturnDate
        {
            get => _returnDate;
            set
            {
                _returnDate = value;
                OnPropertyChanged(nameof(ReturnDate));

                if(value != null && OrderConfig.CurrOrder != null)
                {
                    FinalPrice += PriceCalculator.PricePerDate(OrderConfig.CurrOrder.RentDate, value, OrderConfig.CurrOrder.Price);
                }
            }
        }
        public int DistanceDriven
        {
            get => _distanceDriven;
            set
            {
                _distanceDriven = value;
                OnPropertyChanged(nameof(DistanceDriven));

                if(value != 0 && OrderConfig.CurrOrder != null)
                {
                    FinalPrice += PriceCalculator.PricePerDistance(value, OrderConfig.CurrOrder.Price);
                }
            }
        }

        private void GoHome(object o)
        {
            Mediator.NotifyColleagues("toHome", true);
        }

        private void Confirm(object o)
        {
            var values = (object[])o;
            var distance = Convert.ToInt32(values[0]);
            var returnDate = (DateTime)values[1];
            var feedback = Convert.ToString(values[2]);

            DatabaseManager.ArchiveOrder(OrderConfig.CurrOrder, distance, FinalPrice, feedback);
            DatabaseManager.RemoveOrder(OrderConfig.CurrOrder);
            OrderConfig.CurrOrder = null;

            Mediator.NotifyColleagues("toHome", true);
        }
    }
}
