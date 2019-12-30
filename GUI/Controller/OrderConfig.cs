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

        static private Order _currOrder;
        static string _orderId;

        static OrderConfig()
        {
            CurrOrder = null;
        }

        static public Order CurrOrder
        {
            get => _currOrder;
            set
            {
                _currOrder = value;
                NotifyStaticPropertyChanged(nameof(CurrOrder));

                if(value == null)
                {
                    OrderId = "no current orders";
                }
                else
                {
                    OrderId = value.OrderId;
                }
            }
        }

        static public string OrderId
        {
            get => _orderId;
            set
            {
                _orderId = value;
                NotifyStaticPropertyChanged(nameof(OrderId));
            }
        }
    }
}
