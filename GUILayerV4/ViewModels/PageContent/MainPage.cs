using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUILayerV4.ViewModels.PageContent
{
    public class MainPage : BaseViewModel
    {
        private ICommand _logout;
        public ICommand Logout
        {
            get => _logout;
            set
            {
                _logout = value;
                OnPropertyChanged(nameof(Logout));
            }
        }
    }
}
