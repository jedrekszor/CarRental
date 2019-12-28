using GUILayer.ViewModels.SubVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUILayer.Pages
{
    public class LoginPage
    {
        public string PageTitle { get; set; }
        public ICommand LoadHomePage { get; set; }
    }
}
