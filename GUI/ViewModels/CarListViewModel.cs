using DataLayer.Data;
using DataLayer.Database;
using GUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModels
{
    public class CarListViewModel : PropertyMonitor
    {
        private string _title;
        private List<Car> _cars;
        private DbManager _manager;

        public CarListViewModel()
        {
            _manager = new DbManager(@"C:\Users\Dom\Desktop\ProgrammingTech\ProgTech\CarRentalV2\GUI\bin\Debug\");
            Title = "Car list screen";
            Cars = _manager.GetAllCars();
            GoToHomeCommand = new RelayCommand(o => GoHome(o));
        }

        public ICommand GoToHomeCommand { get; }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public List<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        private void GoHome(object o)
        {
            Mediator.NotifyColleagues("toHome", true);
        }
    }
}
