using DataLayer.Data;
using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.Controller
{
    public static class Authenticator
    {
        private static string Name { get; set; }
        private static string Surname { get; set; }

        public static bool Authenticate(string name, string surname)
        {
            Name = name;
            Surname = surname;

            return DatabaseManager.IfClientExists(name, surname);
        }

        public static void AdminAccess()
        {
            Name = "admin";
            Surname = "admin";

            if (DatabaseManager.IfClientExists("admin", "admin"))
            {
                CurrentUserConfig.CurrentUser = DatabaseManager.GetClient("admin", "admin");
            }
            else
            {
                Client admin = new Client("admin", "admin", "100000", 100);
                DatabaseManager.AddClient(admin);
            }
        }

        public static void Logout()
        {
            CurrentUserConfig.CurrentUser = new Client();
        }

        public static Order GetClientsOrder()
        {
            Order order = null;
            if (DatabaseManager.IfClientAttachedToOrder(Name, Surname))
            {
                order = DatabaseManager.GetOrder(Name, Surname);
                OrderConfig.CurrOrder = order;
            }
            return order;
        }
    }
}