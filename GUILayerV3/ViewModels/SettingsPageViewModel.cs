using GUILayerV3.Command;
using GUILayerV3.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILayerV3.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(SettingsPage model, MainWindowViewModel mainWindowViewModel)
        {
            this.Model = model;
            this.MainWindowViewModel = mainWindowViewModel;
            this.GoToHome = new DelegateCommand(o => this.LogInMethod());
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
            }
        }

        private void LogInMethod()
        {
            MainWindowViewModel.LoadHomePage();
        }
    }
}
