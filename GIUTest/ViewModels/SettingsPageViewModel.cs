using GIULayerV2;
using GIULayerV2.Command;
using GIULayerV2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GIULayerV2.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(SettingsPage model, MainWindowViewModel mainWindowViewModel)
        {
            this.Model = model;
            this.MainWindowViewModel = mainWindowViewModel;
            this.GoToHome = new DelegateCommand(o => this.GoToHomeMethod());
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }
        public SettingsPage Model { get; private set; }

        public string PageTitle
        {
            get
            {
                return this.Model.PageTitle;
            }
            set
            {
                this.Model.PageTitle = value;
                this.OnPropertyChanged("PageTitle");
            }
        }

        public DelegateCommand GoToHome
        {
            get
            {
                return this.Model.GoToHome;
            }
            set
            {
                this.Model.GoToHome = value;
                this.OnPropertyChanged("PageTitle");
            }
        }

        private void GoToHomeMethod()
        {
            MainWindowViewModel.LoadHomePage();
        }
    }
}
