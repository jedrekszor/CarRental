using DataLayer.Data;
using GUILayerV3.Command;
using GUILayerV3.Pages;
using GUILayerV3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUILayerV3
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            this.LoadHomePageCommand = new DelegateCommand(o => this.LoadHomePage());
            this.LoadSettingsPageCommand = new DelegateCommand(o => this.LoadSettingsPage());
            this.LoadLoginPageCommand = new DelegateCommand(o => this.LoadLoginPage());
            this.LoadStartPageCommand = new DelegateCommand(o => this.LoadStartPage());

            this.HomePageViewModel = new HomePageViewModel(HomePage, this);
            this.SettingsPageViewModel = new SettingsPageViewModel(SettingsPage, this);
            this.LoginPageViewModel = new LoginPageViewModel(LoginPage, this);
            this.StartPageViewModel = new StartPageViewModel(StartPage, this);

            //this.CurrentClient = new Client();
            LoadStartPage();
        }

        //Current Client
        private Client _currentClient;
        public Client CurrentClient 
        {
            get { return _currentClient; }
            set
            {
                _currentClient = value;
                this.OnPropertyChanged(nameof(CurrentClient));
                MessageBox.Show("set");
            }
        }

        // Pages
        public LoginPage LoginPage { get; set; } = new LoginPage();
        public HomePage HomePage { get; set; } = new HomePage();
        public SettingsPage SettingsPage { get; set; } = new SettingsPage();
        public StartPage StartPage { get; set; } = new StartPage();

        // Sub viewModels
        SettingsPageViewModel SettingsPageViewModel { get; set; }
        HomePageViewModel HomePageViewModel { get; set; }
        LoginPageViewModel LoginPageViewModel { get; set; }
        StartPageViewModel StartPageViewModel { get; set; }

        // ICommands to controll left bar
        public ICommand LoadHomePageCommand { get; private set; }
        public ICommand LoadSettingsPageCommand { get; private set; }
        public ICommand LoadLoginPageCommand { get; private set; }
        public ICommand LoadStartPageCommand { get; private set; }

        // Current displayed ViewModel
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

        // Loading global methods
        public void LoadHomePage()
        {
            CurrentViewModel = HomePageViewModel;
        }

        public void LoadSettingsPage()
        {
            CurrentViewModel = SettingsPageViewModel;
        }

        public void LoadLoginPage()
        {
            CurrentViewModel = LoginPageViewModel;
        }

        public void LoadStartPage()
        {
            CurrentViewModel = StartPageViewModel;
        }
    }
}
