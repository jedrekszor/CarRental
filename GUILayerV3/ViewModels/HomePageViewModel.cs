using DataLayer.Data;
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
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(HomePage model, MainWindowViewModel windowViewModel)
        {
            this.MainWindowViewModel = windowViewModel;
            this.Model = model;
            this.GoToStart = new DelegateCommand(o => this.GoToStartPageMethod());

            PageTitle = "Main window";
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }
        public HomePage Model { get; private set; }

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

        public DelegateCommand GoToStart
        {
            set
            {
                this.Model.GoToStart = value;
                OnPropertyChanged(nameof(GoToStart));
            }
        }

        public void GoToStartPageMethod()
        {
            MainWindowViewModel.LoadStartPage();
        }
    }
}
