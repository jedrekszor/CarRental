using GUILayerV4.Command;
using GUILayerV4.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUILayerV4.ViewModels.PageContent
{
    public class LoginPage : BaseViewModel
    {
        private string _userName;
        private string _userSurname;
        private ICommand _goHomePage;
        private ICommand _test;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string UserSurname
        {
            get => _userSurname;
            set
            {
                _userSurname = value;
                OnPropertyChanged(nameof(UserSurname));
            }
        }
        public ICommand GoHomePage
        {
            get => _goHomePage;
            set
            {
                _goHomePage = value;
                OnPropertyChanged(nameof(GoHomePage));
            }
        }
        public ICommand Test
        {
            get => _test;
            set
            {
                _test = value;
                OnPropertyChanged(nameof(Test));
            }
        }
    }
}
