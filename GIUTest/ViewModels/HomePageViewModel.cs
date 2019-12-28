using GIULayerV2.Command;
using GIULayerV2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIULayerV2.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(HomePage model, MainWindowViewModel windowViewModel)
        {
            this.MainWindowViewModel = windowViewModel;
            this.Model = model;

            this.GoToHomePage = new DelegateCommand(o => this.GoToSettingsPage());
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }
        public HomePage Model { get; private set; }
        
        public DelegateCommand GoToHomePage { get; private set; }

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

        public void GoToSettingsPage()
        {
            MainWindowViewModel.CurrentViewModel = this;
        }
    }
}
