using GUILayerV3.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUILayerV3.Pages
{
    public class StartPage : ViewModelBase
    {
        public string Invitation { get; set; }
        public string PageTitle { get => _pageTitle; set => _pageTitle = value; }

        private string _alert;
        private string _pageTitle;

        public string Alert
        {
            get
            {
                return _alert;
            }
            set
            {
                _alert = value;
                OnPropertyChanged(nameof(Alert));
            }
        }

        public DelegateCommand GoToHome { get; set; }
    }
}
