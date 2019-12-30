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
<<<<<<< HEAD
        public static bool Authenticate(string name, string surname)
        {
            return DatabaseManager.IfClientExists(name, surname);
=======
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
>>>>>>> f403d439f2162690375ff6a99582a0cd277b622e
        }

        public static void AdminAccess()
        {
<<<<<<< HEAD
            if (DatabaseManager.IfClientExists("admin", "admin"))
            {
                CurrentUserConfig.CurrentUser = DatabaseManager.GetClient("admin", "admin");
=======
            bool check = DbManager.ClientIfExists("admin", "admin");
            if (check)
            {
                CurrentUserConfig.CurrentUser = DbManager.GetClient("admin", "admin");
>>>>>>> f403d439f2162690375ff6a99582a0cd277b622e
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