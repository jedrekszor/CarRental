using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class CheckData
    {
        static CheckData _instance;
        public static CheckData GetInstance()
        {
            if(_instance == null)
            {
                _instance = new CheckData();
            }
            return _instance;
        }

        //ICommand checker
        public static bool CheckObjectArray(object[] obj)
        {
            foreach (object element in obj)
            {
                if (element == null || Convert.ToString(element) == "")
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckParametersArray(object o)
        {
            var values = (object[])o;
            if(values != null)
            {
                foreach (object element in values)
                {
                    if (element == null || Convert.ToString(element) == "")
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public bool CheckParameter(object o)
        {
            return o != null || Convert.ToString(o) == "";
        }

        //Client data checker
        public static bool CheckName(string name)
        {
            return Char.IsUpper(name[0]);
        }
        public static bool CheckSurname(string surname)
        {
            return Char.IsUpper(surname[0]);
        }
        public static bool CheckLicenceNo(string licNo)
        {
            Regex rgx = new Regex(@"^[a-zA-Z0-9]{8}$");
            return rgx.IsMatch(licNo);
        }
        public static bool CheckAge(int age)
        {
            return age >= 18;
        }

        //general checking
        public static bool CheckIfNumber(string num)
        {
            return Int32.TryParse(num, out int numValue);
        }
        public static bool CheckIfWord(string word)
        {
            return Regex.IsMatch(word, @"^[A-Za-z]+$");
        }
        
        public static bool CheckDates(DateTime pickupDate, DateTime returnDate)
        {
            int check = DateTime.Compare(pickupDate, returnDate);

            if (check > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}