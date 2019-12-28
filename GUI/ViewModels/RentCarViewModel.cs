using GUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModels
{
    class RentCarViewModel : PropertyMonitor
    {
        private string _title;

        public RentCarViewModel()
        {
            Title = "Car rent screen";
            GoBackCommand = new RelayCommand(o => GoBack(o));
        }

        public ICommand GoBackCommand { get; }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public void GoBack(object o)
        {
            Mediator.NotifyColleagues("toHome", true);
        }
    }
}
