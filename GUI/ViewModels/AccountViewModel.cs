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
    public class AccountViewModel : PropertyMonitor
    {
        private string _title;
        private string _alert;

        public AccountViewModel()
        {
            Title = "Edit account screen";
            GoToHomeCommand = new RelayCommand(o => GoToHome(o));
            EditCommand = new RelayCommand(o => Edit(o));
        }

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

        public ICommand GoToHomeCommand { get; }
        public ICommand EditCommand { get; }


        private void GoToHome(object o)
        {
            Mediator.NotifyColleagues("toHome", true);
        }

        private void Edit(object o)
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
                            Client edited = new Client(name, surname, licNo, Int32.Parse(age));

                            DatabaseManager.UpdateClient(edited);
                            if (DatabaseManager.IfClientExists(name, surname))
                            {
                                CurrentUserConfig.CurrentUser = DatabaseManager.GetClient(name, surname);
                            }
                            else
                            {
                                Alert = CurrentUserConfig.CurrentUser.Id + " " + name + " " + surname + " not found in database";
                            }
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
    }
}
