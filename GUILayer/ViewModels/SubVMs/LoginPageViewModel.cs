using GUILayer.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUILayer.ViewModels.SubVMs
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.Model = new LoginPage();
            this.MainWindowViewModel = mainWindowViewModel;

            PageTitle = "Login page";
            Model.LoadHomePage = new  DelegateCommand(o => this.LoadHomePage());
        }
 
        public MainWindowViewModel MainWindowViewModel { get; private set; }
        public LoginPage Model { get; private set; }

        public string PageTitle
        {
            get
            {
                return this.Model.PageTitle;
            }
            set
            {
                this.Model.PageTitle = value;
                this.OnPropertyChanged(nameof(PageTitle));
            }
        }

        private void LoadHomePage()
        {
            MessageBox.Show(MainWindowViewModel.CurrentViewModel.ToString());

            MainWindowViewModel.CurrentViewModel = new HomePageViewModel(MainWindowViewModel);
            OnPropertyChanged(nameof(MainWindowViewModel.CurrentViewModel));

            MessageBox.Show(MainWindowViewModel.CurrentViewModel.ToString());
        }
    }
}
