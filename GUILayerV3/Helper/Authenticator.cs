using DataLayer.Data;
using DataLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILayerV3.Helper
{
    public static class Authenticator
    {
//        private static DbManager manager = new DbManager();

        public static bool Authenticate(string name, string surname)
        { 
            return DbManager.ClientIfExists(name, surname);
        }

        public static Client GetClient(string name, string surname)
        {
            return DbManager.GetClient(name, surname);
        }
    }
}