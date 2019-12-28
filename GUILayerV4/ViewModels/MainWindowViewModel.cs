using DataLayer.Data;
using GUILayerV4.Command;
using GUILayerV4.Helper;
using GUILayerV4.ViewModels.PageContent;
using GUILayerV4.ViewModels.PageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUILayerV4.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        // Globally visible current user
        private Client _currentUser;
        public Client CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        // Current view model
        private IPageViewModel _currentPageViewModel;
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        // View models
        public MainViewModel MainViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }

        // Pages operation methods
        public void LoadHomeScreen(object obj)
        {
            _currentPageViewModel = MainViewModel;
        }
        public void LoadLoginScreen(object obj)
        {
            _currentPageViewModel = LoginViewModel;
        }

        // Pages contents
        public LoginPage LoginPage { get; private set; }
        public MainPage  MainPage { get; private set; }

        public MainWindowViewModel()
        {
            CurrentUser = new Client();
            LoginPage = new LoginPage();
            MainPage = new MainPage();

            MainViewModel = new MainViewModel(this, MainPage);
            LoginViewModel = new LoginViewModel(this, LoginPage);

            Mediator.Subscribe("GoHomeScreen", LoadHomeScreen);
            Mediator.Subscribe("GoLoginScreen", LoadLoginScreen);

            Mediator.Notify("GoHomeScreen", "");
        }
    }
}
