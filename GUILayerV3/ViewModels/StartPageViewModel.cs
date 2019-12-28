using GUILayerV3.Command;
using GUILayerV3.Helper;
using GUILayerV3.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUILayerV3.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        public StartPageViewModel(StartPage model, MainWindowViewModel mainWindowViewModel)
        {
            this.Model = model;
            this.MainWindowViewModel = mainWindowViewModel;
            Model.GoToHome = new DelegateCommand(o => LogInMethod(o));
            Invitation = "Welcome in our application";
            PageTitle = "Start page";
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }
        public StartPage Model { get; private set; }

        public string Invitation
        {
            get
            {
                return this.Model.Invitation;
            }
            set
            {
                this.Model.Invitation = value;
                OnPropertyChanged(nameof(Invitation));
            }
        }

        public string PageTitle
        {
            get
            {
                return this.Model.PageTitle;
            }
            set
            {
                this.Model.PageTitle = value;
                OnPropertyChanged(nameof(PageTitle));
            }
        }

        public string Alert
        {
            set
            {
                this.Model.Alert = value;
                OnPropertyChanged(nameof(Alert));
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
                OnPropertyChanged(nameof(GoToHome));
            }
        }

        private void LogInMethod(object parameter)
        {
            var values = (object[])parameter;
            string name = Convert.ToString((string)values[0]);
            string surname = Convert.ToString((string)values[1]);

            if (Authenticator.Authenticate(name, surname))
            {
                MainWindowViewModel.CurrentClient = Authenticator.GetClient(name, surname);
                MessageBox.Show(MainWindowViewModel.CurrentClient.ToString());
                MainWindowViewModel.LoadHomePage();
            }
            else
            {
                //nie działa
                PageTitle = "wrong name or surname!";
                OnPropertyChanged(nameof(PageTitle));
            }
        }
    }
}