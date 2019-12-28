using PresentationLayer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.viewModel
{
    public class ViewModelHome : ViewModelBase
    {
        public ViewModelHome(HomePage model)
        {
            this.Model = model;
        }

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
