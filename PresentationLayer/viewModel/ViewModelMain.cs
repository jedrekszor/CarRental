using System;
using System.Windows;
using System.Windows.Controls;
using DataLayer.Data;
using PresentationLayer.helper;
using PresentationLayer.viewModel.commands;

namespace PresentationLayer.viewModel
{
    public class ViewModelMain : ViewModelBase
    {
        //Pages flags
        public bool LoginVisibility { get; set; }


        //Client info
        private Client _currentUser;
        public Client CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }


        //View model classes
        private ViewModelLogin ViewModelLogin { get; set; }


        //ICommands
        public ChangeTextCommand ChangeTextCommand { get; set; }
        public LogInCommand LogInCommand { get; set; }


        public ViewModelMain()
        {
            this.ChangeTextCommand = new ChangeTextCommand(this);
            this.LogInCommand = new LogInCommand(this);

            ViewModelLogin = new ViewModelLogin(this);
  
            CurrentUser = new Client();

            LoginVisibility = true;
        }
        
        //Commands methods
        public void ChangeTextMethod(object parameter)
        {
            var values = (object[])parameter;
            CurrentUser.Name = (string)values[0];
            CurrentUser.Surname = (string)values[1];
        }

        public void LogInMethod(object parameter)
        {
            ViewModelLogin.LogButtonClick(parameter);

            LoginVisibility = false;
            OnPropertyChanged(nameof(LoginVisibility));
        }
    }
}