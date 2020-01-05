using DataLayer.Data;
using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controller
{
    public static class Authenticator
    {
        public static bool Authenticate(string name, string surname)
        {
            return DatabaseManager.IfClientExists(name, surname);
        }

        public static void AdminAccess()
        {
            if (DatabaseManager.IfClientExists("admin", "admin"))
            {
                CurrentUserConfig.CurrentUser = DatabaseManager.GetClient("admin", "admin");
            }
            else
            {
                Client admin = new Client("admin", "admin", "100000", 100);
                DatabaseManager.AddClient(admin);

                CurrentUserConfig.CurrentUser = DatabaseManager.GetClient("admin", "admin");
            }
        }

        public static void Logout()
        {
            CurrentUserConfig.CurrentUser = new Client();
        }
    }
}