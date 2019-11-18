using System.Windows;
using System.Windows.Controls;
using DataLayer.Data;
using PresentationLayer.helper;
using PresentationLayer.view;
using PresentationLayer.viewModel.commands;

namespace PresentationLayer.viewModel
{
    public class ViewModelLogin : ViewModelBase
    {
        public Authentication Authentication { get; set; }
        public ViewModelMain ViewModelMain { get; set; }
        public Client CurrentUser { get; set; }
        private bool _isLogged;
        public bool IsLogged
        {
            get => _isLogged;
            set
            {
                _isLogged = value;
                OnPropertyChanged(nameof(IsLogged));
            }
        }

        public ViewModelLogin(ViewModelMain viewModelMain)
        {
            ViewModelMain = viewModelMain;
            Authentication = new Authentication();
        }

        public void LogButtonClick(object parameter)
        {
            var values = (object[])parameter;

            var userName = (string)values[0];
            var userSurname = (string)values[1];

            if (Authentication.Authenticate(userName, userSurname))
            {
                //tutaj getClient z database
                ViewModelMain.CurrentUser = Authentication.GetAuthenticatedClient(userName, userSurname);
            }
        }

        public void LogButtonClickAdmin()
        {
            //tutaj od razu nowy
            ViewModelMain.CurrentUser = new Client("Admin", "Admin", "11111", 25);
        }
    }
}