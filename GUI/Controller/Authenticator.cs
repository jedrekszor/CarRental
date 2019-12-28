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
//        private static DbManager manager = new DbManager();

        public static bool Authenticate(string name, string surname)
        {
            bool check = DbManager.ClientIfExists(name, surname);

            if (check)
            {
                CurrentUserConfig.CurrentUser = DbManager.GetClient(name, surname);
                return true;
            }
            else
                return false;
        }

        public static void AdminAccess()
        {
            bool check = DbManager.ClientIfExists("admin", "admin");
            if (check)
            {
                CurrentUserConfig.CurrentUser = DbManager.GetClient("admin", "admin");
            }
            else
                CurrentUserConfig.CurrentUser = new DataLayer.Data.Client("admin", "admin", "100000", 25);
        }

        public static void Logout()
        {
            CurrentUserConfig.CurrentUser = new DataLayer.Data.Client();
        }
    }
}