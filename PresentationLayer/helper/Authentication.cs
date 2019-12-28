using DataLayer.Data;
using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.helper
{
    //class used for authenticating and passing client from db.
    public class Authentication
    {
        private static DbManager manager = new DbManager();
        public static DbManager Manager { get => manager; set => manager = value; }

        public static bool Authenticate(string name, string surname)
        {
            //add db_manager if client exists
            return true;
        }

        public static Client GetAuthenticatedClient(string name, string surname)
        {
            Client client = new Client(name, surname, "111101", 25);

            manager.RemoveClient(client);
            manager.AddClient(client);
            return Manager.GetClient(name, surname);
        }
    }
}
