using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Selenium_Wizard.Models;
using Selenium_Wizard.Data;
using Selenium_Wizard.Data.Helpers;

namespace Selenium_Wizard.ViewModels
{
    public class ViewModel_Automation_Types:INotifyPropertyChanged
    {

        private Automation_Types _currentDbConnection = new Automation_Types();
        private readonly GenericDataService<Automation_Types> Repo_Connections;

        public ICommand cmdAddButton { get; set; }
        public ICommand cmdUpdateButton { get; set; }
        public ICommand cmdDeleteButton { get; set; }
        public ICommand cmdHelloButton { get; set; }
    


        private bool _isLoading;

        public bool isLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(nameof(isLoading)); OnPropertyChanged(nameof(LoadingBar)); OnPropertyChanged(nameof(LoadingBarVisibility)); }
        }


        private Visibility _LoadingBar;

        public Visibility LoadingBar
        {
            get { return isLoading == true ? Visibility.Collapsed : Visibility.Visible; }

        }

        private Visibility _LoadingBarVisibility;

        public Visibility LoadingBarVisibility
        {
            get { return isLoading == true ? Visibility.Visible : Visibility.Collapsed; }

        }


       



        public ViewModel_Automation_Types()
        {
            cmdAddButton = new Command((s) => true, Add_Record);
            Repo_Connections = new GenericDataService<Automation_Types>(new DbContextFactory());

            cmdDeleteButton = new Command((s) => true, Delete_Record);
            cmdUpdateButton = new Command((s) => true, Update_Record);
     



        }




        public void Message_Record(object sender, RoutedEventArgs a)
        {
            MessageBox.Show("HELLO");

        }




        public async void Load_Connections()
        {
            ObservableCollection<Automation_Types> Temp = new ObservableCollection<Automation_Types>();
            await Task.Run(() =>
            {
                isLoading = true;
                Temp = new ObservableCollection<Automation_Types>(Repo_Connections.GetAllNormal());
                isLoading = false;
            });

            ListOfDbConnections = Temp;
            OnPropertyChanged(nameof(ListOfDbConnections));
        }

        public Automation_Types CurrentDbConnection
        {
            get => _currentDbConnection;
            set { _currentDbConnection = value; OnPropertyChanged(nameof(CurrentDbConnection)); }
        }

        private ObservableCollection<Automation_Types> _ListOfDbConnections=new ObservableCollection<Automation_Types>();



        public ObservableCollection<Automation_Types> ListOfDbConnections
        {
            get { return _ListOfDbConnections; }
            set { _ListOfDbConnections = value; OnPropertyChanged(nameof(ListOfDbConnections)); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private async void Update_Record(object s)
        {
            try
            {

                string? Record_umber = s as string;
                CurrentDbConnection = await Repo_Connections.Get(Record_umber!);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR : {ex.Message}");
            }

        }

        private async void Add_Record(object s)
        {


            Automation_Types TempRecord = new Automation_Types();


            try
            {
                if (CurrentDbConnection.ID == 0)
                {

                    TempRecord = await Repo_Connections.Create(CurrentDbConnection);
                    MessageBox.Show("RECORD ADDED SUCCESSFULLY");
                }

                else
                {
                    TempRecord = await Repo_Connections.Update(CurrentDbConnection);
                    MessageBox.Show("RECORD UPDATED SUCCESSFULLY");

                }


                ListOfDbConnections.Add(TempRecord);
                CurrentDbConnection = new Automation_Types();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR : {ex.Message}");
            }








        }



        public async Task Page_Loaded()
        {
            await Task.Run(() =>
            {

                Load_Connections();

            });
        }

        private async void Delete_Record(object s)
        {
            try
            {
                bool is_File_Deleted = false;
                int Record_Id = Convert.ToInt32(s);
                Automation_Types TypeObject = await Repo_Connections.GetInt(Record_Id);
                is_File_Deleted = await Repo_Connections.Delete(TypeObject);
                if (is_File_Deleted)
                {
                    MessageBox.Show("RECORD DELETED SUCCESSFULLY");
                    Automation_Types? Temp_Record = ListOfDbConnections.FirstOrDefault(x => x.ID == Record_Id);
                    if (Temp_Record != null)
                    {
                        ListOfDbConnections.Remove(Temp_Record);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR : {ex.Message}");
            }
        }
    }
}
