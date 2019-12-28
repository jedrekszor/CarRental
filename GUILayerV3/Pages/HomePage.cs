using GUILayerV3.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILayerV3.Pages
{
    public class HomePage : ViewModelBase
    {
        public string PageTitle { get; set; }
        public DelegateCommand GoToStart { get; set; }

        public string v_ClientName { get; set; }
        public string v_ClientSurname { get; set; }

    }
}
