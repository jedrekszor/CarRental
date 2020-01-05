using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public static class PriceCalculator
    {
        public static double PricePerDistance(int distanceDriven, float price)
        {
            return Math.Round(distanceDriven * price * 0.005);
        }

        public static double PricePerDate(DateTime pickupDate, DateTime returnDate, float price)
        {
            return Math.Round((returnDate - pickupDate).TotalDays * price * 0.8);
        }
    }
}
