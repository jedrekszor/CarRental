using DataLayer.Data;
using DataLayer.Database;
using GUI.Controller;
using GUI.Helper;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI.ViewModels
{
    class NewUserViewModel : PropertyMonitor
    {
        private string _title;
        private string _alert;

        public bool CheckBox1 { get; set; }
        public bool CheckBox2 { get; set; }

        public NewUserViewModel()
        {
            Title = "New user screen";
            Alert = "";

            CheckData check = CheckData.GetInstance();
            GoToMainCommand = new RelayCommand(o => GoToMain(o));
            SubmitCommand = new RelayCommand(o => Submit(o), o => check.CheckParametersArray(o));
        }

        private void GoToMain(object o)
        {
            Mediator.NotifyColleagues("toLogin", true);
        }

        private void Submit(object o)
        {
            Alert = "";
            bool check = true;

            var values = (object[])o;
            if (CheckData.CheckObjectArray(values))
            {
                var name = (string)values[0];
                var surname = (string)values[1];
                var licNo = (string)values[2];
                var age = (string)values[3];

                check = CheckData.CheckIfWord(name) &&
                        CheckData.CheckIfWord(surname) &&
                        CheckData.CheckIfNumber(age);
                
                if (check)
                {
                    if (!DatabaseManager.IfClientExists(name, surname))
                    {
                        if (CheckBox1 == true && CheckBox2 == true)
                        {
                            if (!CheckData.CheckName(name) || !CheckData.CheckName(surname))
                            {
                                Alert = "Name or surname is incorrect";
                                check = false;
                            }
                            if (!CheckData.CheckLicenceNo(licNo))
                            {
                                Alert = "Liecence no is incorrect";
                                check = false;
                            }
                            if (!CheckData.CheckAge(Int32.Parse(age)))
                            {
                                Alert = "You must be over 18.";
                                check = false;
                            }

                            if (check)
                            {
                                Client newUser = new Client(name, surname, licNo, Int32.Parse(age));
                                DatabaseManager.AddClient(newUser);
                                CurrentUserConfig.CurrentUser = DatabaseManager.GetClient(newUser.Id);

                                Mediator.NotifyColleagues("toHome", true);
                            }
                        }
                        else
                        {
                            Alert = "Tick all checkboxes";
                        }
                    }
                    else
                    {
                        Alert = "Such client already exists";
                    }
                }
                else
                {
                    Alert = "Check if word is a word and number is a number";
                }
            }
        }

        public ICommand GoToMainCommand { get; }
        public ICommand SubmitCommand { get; }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Alert
        {
            get => _alert;
            set
            {
                _alert = value;
                OnPropertyChanged(nameof(Alert));
            }
        }
    }
}
