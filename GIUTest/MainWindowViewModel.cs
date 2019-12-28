using GIULayerV2.Command;
using GIULayerV2.Pages;
using GIULayerV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GIULayerV2
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            // Hook up Commands to associated methods
            this.LoadHomePageCommand = new DelegateCommand(o => this.LoadHomePage());
            this.LoadSettingsPageCommand = new DelegateCommand(o => this.LoadSettingsPage());

            this.HomePageViewModel = new HomePageViewModel(new HomePage(), this);
            this.SettingsPageViewModel = new SettingsPageViewModel(new SettingsPage(), this);


            LoadHomePage();
        }

        SettingsPageViewModel SettingsPageViewModel { get; set; }
        HomePageViewModel HomePageViewModel { get; set; }

        public ICommand LoadHomePageCommand { get; private set; }
        public ICommand LoadSettingsPageCommand { get; private set; }

        // ViewModel that is currently bound to the ContentControl
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        }

        public void LoadHomePage()
        {
            CurrentViewModel = HomePageViewModel;
        }

        public void LoadSettingsPage()
        {
            CurrentViewModel = SettingsPageViewModel;
        }
    }
}
