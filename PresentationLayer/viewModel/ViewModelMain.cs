using PresentationLayer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.viewModel
{
    class ViewModelMain : ViewModelBase
    {

        public string Text = "DUPA";

        public ViewModelMain()
        {
            LoadHomePage();
        }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                this.OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        //Methods:
        private void LoadHomePage()
        {
            CurrentViewModel = new ViewModelHome(new HomePage() { PageTitle = "This is the Home Page." });
        }
    }
}
