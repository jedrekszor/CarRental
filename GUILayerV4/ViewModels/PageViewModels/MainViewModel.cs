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
    public class MainViewModel : BaseViewModel, IPageViewModel
    {
        public MainViewModel(MainWindowViewModel mainModel, MainPage mainPage)
        {
            this.MainModel = mainModel;

            mainPage.Logout = new RelayCommand(o =>
            {
                MainModel.LoadLoginScreen(o);
            });
        }

        private MainWindowViewModel MainModel { get; set; }
        private MainPage PageContent { get; set; }
        public Client CurrentUser { get; set; }
    }
}
