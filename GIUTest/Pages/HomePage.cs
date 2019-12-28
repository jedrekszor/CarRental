using GIULayerV2.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIULayerV2.Pages
{
    public class HomePage
    {
        public string PageTitle { get; set; }
        public DelegateCommand GoToSettings { get; set; }
    }
}
