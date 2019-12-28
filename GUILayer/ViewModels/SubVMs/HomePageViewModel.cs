using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILayer.ViewModels.SubVMs
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(MainWindowViewModel mainWindowViewModel)
        {
            this.Model = new HomePage();
            this.MainWindowViewModel = mainWindowViewModel;

            PageTitle = "Home page";
        }

        public MainWindowViewModel MainWindowViewModel { get; private set; }
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
                this.OnPropertyChanged("PageTitle");
            }
        }
    }
}
