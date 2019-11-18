using PresentationLayer.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace PresentationLayer.helper
{
    enum ApplicationPage
    {
        LoginPage,
        MainPage,
    }

    //class used to switch between pages (in progress)
    class ApplicationController
    {
        static ApplicationController _instance;
        public static ApplicationController GetInstance()
        {
            if (_instance == null)
                _instance = new ApplicationController();
            return _instance;
        }

        Border _stage;

        private ApplicationController() { }

        public void GoToPage(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.LoginPage:
                    _stage.Child = new LoginPage();
                    break;
                case ApplicationPage.MainPage:
                    _stage.Child = new MainPage();
                    break;
            }
        }

        public void SetStage(Border Stage)
        {
            _stage = Stage;
        }
    }
}
