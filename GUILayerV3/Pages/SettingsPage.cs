using GUILayerV3.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILayerV3.Pages
{
    public class SettingsPage
    {
        public string PageTitle { get; set; }
        public DelegateCommand GoToHome { get; set; }
    }
}
