using DataLayer.Data;
using GUILayerV4.Command;
using GUILayerV4.Helper;
using GUILayerV4.ViewModels.PageContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUILayerV4.ViewModels.PageViewModels
{
    public class LoginViewModel : BaseViewModel, IPageViewModel
    {
        public LoginViewModel(MainWindowViewModel mainModel, LoginPage loginPage)
        {
            this.MainModel = mainModel;
            this.PageContent = loginPage;

            UserName = MainModel.CurrentUser.Name;
            UserSurname = MainModel.CurrentUser.Surname;

            loginPage.GoHomePage = new RelayCommand(o =>
            {
                Mediator.Notify("GoHomeScreen", "");
            });

            loginPage.Test = new RelayCommand(o =>
            {
                Mediator.Notify("GoHomeScreen", "");
            });
        }

        private MainWindowViewModel MainModel {get; set;}
        private LoginPage PageContent { get; set; }
        public Client CurrentUser { get; set; }

        public string UserName
        {
            get
            {
                return PageContent.UserName;
            }
            set
            {
                PageContent.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string UserSurname
        {
            get
            {
                return PageContent.UserSurname;
            }
            set
            {
                PageContent.UserSurname = value;
                OnPropertyChanged(nameof(UserSurname));
            }
        }
    }
}
