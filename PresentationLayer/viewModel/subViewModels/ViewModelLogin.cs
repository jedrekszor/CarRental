using System.Windows;
using System.Windows.Controls;
using DataLayer.Data;
using PresentationLayer.helper;
using PresentationLayer.model;
using PresentationLayer.viewModel.commands; 

namespace PresentationLayer.viewModel
{
    public class ViewModelLogin : ViewModelBase
    {
        public ViewModelLogin(LoginPage model)
        {
            this.Model = model;
        }

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
                this.OnPropertyChanged("PageTitle");
            }
        }
    }
}