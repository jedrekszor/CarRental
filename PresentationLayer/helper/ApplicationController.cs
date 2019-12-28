using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace PresentationLayer.helper
{
    public class ApplicationController
    {
        public ApplicationController(ApplicationPage page)
        {
            GoToPage(page);
        }

        public int SwitchView { get; set; }


        private void GoToPage(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.LoginPage:
                    SwitchView = (int)ApplicationPage.LoginPage;
                    break;
                case ApplicationPage.MainPage:
                    SwitchView = (int)ApplicationPage.MainPage;
                    break;
                case ApplicationPage.ClientPage:
                    SwitchView = (int)ApplicationPage.ClientPage;
                    break;
            }
        }
    }

    public enum ApplicationPage
    {
        LoginPage = 0,
        MainPage = 1,
        ClientPage = 2,
    }
}  
