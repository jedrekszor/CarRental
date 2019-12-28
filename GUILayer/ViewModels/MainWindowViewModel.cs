using GUILayer.Pages;
using GUILayer.ViewModels.SubVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUILayer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            // Hook up Commands to associated methods
            this.LoadHomePageCommand = new DelegateCommand(o => this.LoadHomePage());
            this.LoadSettingsPageCommand = new DelegateCommand(o => this.LoadSettingsPage());

       

            this.LoginPageViewModel = new LoginPageViewModel(this);
            this.HomePageViewModel = new HomePageViewModel(this);

            this.LoadLoginPage();
        }

        public LoginPageViewModel LoginPageViewModel { get; set; }
        public HomePageViewModel HomePageViewModel { get; set; }

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
                this.OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public void LoadHomePage()
        {
            CurrentViewModel = HomePageViewModel;
            this.OnPropertyChanged(nameof(CurrentViewModel));
        }

        public void LoadSettingsPage()
        {
            CurrentViewModel = new SettingsPageViewModel(
                new SettingsPage() { PageTitle = "This is the Settings Page." });
        }

        public void LoadLoginPage()
        {
            CurrentViewModel = new LoginPageViewModel(this);
            this.OnPropertyChanged("CurrentViewModel");
        }
    }
}
