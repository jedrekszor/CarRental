using DataLayer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    public static class OrderConfig
    {
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        #region OrderInfo

        static private Order _currOrder;
        static private string _orderInfo;
       
        static OrderConfig()
        {
            _currOrder = new Order();
            CurrCar = new Car();
            OrderVisibility = false;
        }

        static public Order CurrOrder
        {
            get => _currOrder;
            set
            {
                _currOrder = value;
                NotifyStaticPropertyChanged(nameof(CurrOrder));

                if (value != null)
                {
                    OrderInfo = value.ToString();
                    CurrCar = value.Car;
                }
                else
                {
                    OrderInfo = "no orders found";
                }
            }
        }

        //order visibility flag in main view
        static bool _orderVisibility;
        static public bool OrderVisibility
        {
            get { return _orderVisibility; }
            set
            {
                _orderVisibility = value;
                NotifyStaticPropertyChanged(nameof(OrderVisibility));
            }
        }

        static public string OrderInfo
        {
            get => _orderInfo;
            private set
            {
                _orderInfo = value;
                NotifyStaticPropertyChanged(nameof(OrderInfo));
            }
        }

        #endregion

        #region CarInfo

        private static Car _currCar;
        private static int _mileage;
        private static float _price;

        public static Car CurrCar
        {
            get => _currCar;
            set
            {
                _currCar = value;
                NotifyStaticPropertyChanged(nameof(CurrCar));

                if (value != null)
                {
                    Mileage = value.Mileage;
                    Price = value.Price;
                }
            }
        }
        public static int Mileage
        {
            get => _mileage;
            set
            {
                _mileage = value;
                NotifyStaticPropertyChanged(nameof(Mileage));
            }
        }
        public static float Price
        {
            get => _price;
            set
            {
                _price = value;
                NotifyStaticPropertyChanged(nameof(Price));
            }
        }

        #endregion

        public static void ClearCurrOrder()
        {
            _currOrder = new Order();
            CurrCar = new Car();
            OrderVisibility = false;
        }

        public static void ShowOrder()
        {
            OrderVisibility = true;
        }
        public static void HideOrder()
        {
            OrderVisibility = false;
        }
    }
}
