using Selenium_Wizard.Data;
using Selenium_Wizard.Models;
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
using Selenium_Wizard.Data.Helpers;

namespace Selenium_Wizard.ViewModels
{
    public  class VIewModel_TypeNames : INotifyPropertyChanged
    {

        private Automation_Names _currentDbConnection = new Automation_Names();
        private readonly GenericDataService<Automation_Names> Repo_Connections;

        public ICommand cmdAddButton { get; set; }
        public ICommand cmdUpdateButton { get; set; }
        public ICommand cmdDeleteButton { get; set; }
        public ICommand cmdHelloButton { get; set; }


        public List<Automation_Types> DropDownValues { get; set; }
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




        public void LoadAllDropDownValues()
        {
            DropDownValues = new List<Automation_Types>();

            GenericDataService<Automation_Types> Type_DataService = new GenericDataService<Automation_Types>(new DbContextFactory());
            DropDownValues = Type_DataService.GetAllNormal();

        }


        public VIewModel_TypeNames()
        {
            cmdAddButton = new Command((s) => true, Add_Record);
            Repo_Connections = new GenericDataService<Automation_Names>(new DbContextFactory());

            cmdDeleteButton = new Command((s) => true, Delete_Record);
            cmdUpdateButton = new Command((s) => true, Update_Record);

            LoadAllDropDownValues();


        }




        public void Message_Record(object sender, RoutedEventArgs a)
        {
            MessageBox.Show("HELLO");

        }




        public async void Load_Connections()
        {
            ObservableCollection<Automation_Names> Temp = new ObservableCollection<Automation_Names>();
            await Task.Run(() =>
            {
                isLoading = true;
                Temp = new ObservableCollection<Automation_Names>(Repo_Connections.GetAllNormal());
                isLoading = false;
            });

            ListOfDbConnections = Temp;
        }

        public Automation_Names CurrentDbConnection
        {
            get => _currentDbConnection;
            set { _currentDbConnection = value; OnPropertyChanged(nameof(CurrentDbConnection)); }
        }

        private ObservableCollection<Automation_Names> _ListOfDbConnections;



        public ObservableCollection<Automation_Names> ListOfDbConnections
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


            Automation_Names TempRecord = new Automation_Names();


            try
            {
                if (CurrentDbConnection.Id == 0)
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
                CurrentDbConnection = new Automation_Names();

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
                Automation_Names TypeObject = await Repo_Connections.GetInt(Record_Id);
                is_File_Deleted = await Repo_Connections.Delete(TypeObject);
                if (is_File_Deleted)
                {
                    MessageBox.Show("RECORD DELETED SUCCESSFULLY");
                    Automation_Names? Temp_Record = ListOfDbConnections.FirstOrDefault(x => x.Id == Record_Id);
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
