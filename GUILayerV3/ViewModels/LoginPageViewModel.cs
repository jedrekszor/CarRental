using GUILayerV3.Command;
using GUILayerV3.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUILayerV3.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(LoginPage model, MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
            Model = model;

            model.LogInCommand = new DelegateCommand(o => this.LoginMethod());
        }

        MainWindowViewModel MainWindowViewModel { get; set; }
        public LoginPage Model { get; private set; }

        private void LoginMethod()
        {
            MainWindowViewModel.LoadHomePage();
        }
    }
}
