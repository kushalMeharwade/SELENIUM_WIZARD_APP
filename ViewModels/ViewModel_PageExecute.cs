using Microsoft.Win32;
using Selenium_Wizard.Data;
using Selenium_Wizard.Data.Helpers;
using Selenium_Wizard.Helpers;
using Selenium_Wizard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Selenium_Wizard.ViewModels
{
  public   class ViewModel_PageExecute : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private Page_Execute _currentPageExecute=new Page_Execute();

        public Page_Execute currentPageExecute
        {
            get { return _currentPageExecute; }
            set { _currentPageExecute = value;OnPropertyChanged(nameof(currentPageExecute)); }
        }

        private ObservableCollection<Automation_Names>_ListOfPageNames=new ObservableCollection<Automation_Names>();

        public ObservableCollection<Automation_Names> ListOfPagesNames
        {
            get { return _ListOfPageNames; }
            set { _ListOfPageNames = value; OnPropertyChanged(nameof(ListOfPagesNames)); }
        }



        private ObservableCollection<Automation_Names> _ListOfPagesLogin=new ObservableCollection<Automation_Names>();

        public ObservableCollection<Automation_Names> ListOfPagesLogin
        {
            get { return _ListOfPagesLogin; }
            set { _ListOfPagesLogin = value;OnPropertyChanged(nameof(ListOfPagesLogin)); }
        }


        private ObservableCollection<Automation_Names> _ListOfPagesData = new ObservableCollection<Automation_Names>();

        public ObservableCollection<Automation_Names> ListOfPagesData
        {
            get { return _ListOfPagesData; }
            set { _ListOfPagesData = value; OnPropertyChanged(nameof(ListOfPagesData)); }
        }


        // Element Log List



        private ObservableCollection<Element_Log> _ListOfElementLogs = new ObservableCollection<Element_Log>();

        public ObservableCollection<Element_Log> ListOfElementLogs
        {
            get { return _ListOfElementLogs; }
            set { _ListOfElementLogs = value; OnPropertyChanged(nameof(ListOfElementLogs)); }
        }


        #region Button and Event Handlers

        private string? _buttonText="RUN";

        public string? buttonText
        {
            get { return _buttonText; }
            set { _buttonText= value;OnPropertyChanged(nameof(buttonText)); }
        }


        private bool _isButtonEnabled=true;

        public bool isButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { _isButtonEnabled = value; OnPropertyChanged(nameof(isButtonEnabled)); }
        }



        private int _MaxValue;

        public int MaxValue
        {
            get { return _MaxValue; }
            set { _MaxValue = value; OnPropertyChanged(nameof(MaxValue)); }
        }



        private int _CurrentValue;

        public int CurrentValue
        {
            get { return _CurrentValue; }
            set { _CurrentValue = value; OnPropertyChanged(nameof(CurrentValue)); }
        }


        #endregion



        public ICommand cmdSelectLogin { get; set; }
        public ICommand cmdSelectData { get; set; }
        public ICommand cmdExecute { get; set; }



        public void cmdSelectLoginFunction(object s)
        {

            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog
            {
                
                Title = "SELECT EXCEL FILES",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xls",
                Filter = "Excel files (*.xls)|*.xls",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

         
            Nullable<bool> result= openFileDialog1.ShowDialog();
            if (result == true)
            {
                currentPageExecute.FIlePath_1= openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("OPERATION CANCELED");
            }


        }
       
        public void cmdSelectDataFunction(object s)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog
            {

                Title = "SELECT EXCEL FILES",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xls",
                Filter = "Excel files (*.xls)|*.xls",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };


            Nullable<bool> result = openFileDialog1.ShowDialog();
            if (result == true)
            {
                currentPageExecute.FIlePath_2 = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("OPERATION CANCELED");
            }


        }

        public void cmdExecuteFunction(object s)
        {

            isButtonEnabled = false;
            buttonText = "PLEASE WAIT.....";
            List<Element_Item> Login_Data_Elements = new List<Element_Item>();
            List<Element_Item> Data_Loop_Elements = new List<Element_Item>();
            SeleniumHelper HelperSelenium = new SeleniumHelper();
            
            DataTable login_Data = new DataTable();
            DataTable data_Loop_Data = new DataTable();

            if (string.IsNullOrEmpty(currentPageExecute.baseUrl))
            {
                throw new Exception("PLEASE ENTER BASE URL ");

            }


            try
            {
                GenericDataService<Element_Item> Elements_DataService = new GenericDataService<Element_Item>(new DbContextFactory());
               if(currentPageExecute.LoginPageCode != -1)
                {
                    Login_Data_Elements = Elements_DataService.GetAllWithCondition(i => i.PageCode == currentPageExecute.LoginPageCode).OrderBy(i=>i.Order).ToList();

                }
                Data_Loop_Elements = Elements_DataService.GetAllWithCondition(i => i.PageCode == currentPageExecute.dataPageCode).OrderBy(i => i.Order).ToList();


                if(currentPageExecute.LoginPageCode != -1)
                {
                    if (!String.IsNullOrEmpty(currentPageExecute.FIlePath_1))
                    {
                        login_Data = ExcelHelper.GetDataTable(currentPageExecute.FIlePath_1);


                    }
                    else
                    {
                        throw new Exception("PLEASE SELECT EXCEL FILE");
                    }
                }
              


                if (!String.IsNullOrEmpty(currentPageExecute.FIlePath_2))
                {
                     data_Loop_Data = ExcelHelper.GetDataTable(currentPageExecute.FIlePath_2);

                }
                else
                {
                    throw new Exception("PLEASE SELECT EXCEL FILE");

                }

                if(currentPageExecute.LoginPageCode != -1)
                {
                    if (login_Data.Rows.Count == 0)
                    {
                        throw new Exception("NO DATA FOUND IN EXCEL LOGIN");
                    }
                    else
                    {
                        MaxValue = login_Data.Rows.Count;
                        HelperSelenium.IterateMethodsAndExecuteLogin(Login_Data_Elements, login_Data, currentPageExecute.baseUrl, ListOfElementLogs, CurrentValue);
                    }
                }


             

                if (data_Loop_Data.Rows.Count == 0)
                {
                    throw new Exception("NO DATA FOUND IN EXCEL DATA");

                }
                else
                {
                    MaxValue = data_Loop_Data.Rows.Count;
                    HelperSelenium.IterateMethodsAndExecute(Data_Loop_Elements, data_Loop_Data, currentPageExecute.baseUrl, ListOfElementLogs, CurrentValue);

                }




            }
            catch(Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }


            isButtonEnabled = true;
            buttonText = "RUN";


        }
        public ViewModel_PageExecute()
        {
            cmdSelectLogin = new Command((s) => true, cmdSelectLoginFunction);
            cmdSelectData = new Command((s) => true, cmdSelectDataFunction);
            cmdExecute = new Command((s) => true, cmdExecuteFunction);
        }
        private void LoadAllPagesData()
        {
            GenericDataService<Automation_Names> TypeNamesDataService = new GenericDataService<Automation_Names>(new DbContextFactory());
            List<Automation_Names> Temp_ListOfAutomationNames = new List<Automation_Names>();
            Temp_ListOfAutomationNames = TypeNamesDataService.GetAllNormal();

            ListOfPagesNames = new ObservableCollection<Automation_Names>(Temp_ListOfAutomationNames);

            List<Automation_Names> temp_LoginDataNames= new List<Automation_Names>();
            List<Automation_Names> temp_Data = new List<Automation_Names>();
            temp_LoginDataNames = Temp_ListOfAutomationNames.Where(i => i.typeName == "LOGIN").ToList();
            temp_Data = Temp_ListOfAutomationNames.Where(i => i.typeName != "LOGIN").ToList();
            temp_LoginDataNames.Insert(0, new Automation_Names
            {
                Name = "NOT APPLIED",
                typeCode = -1,
                typeName = "NOT APPLIED",
                Id = -1
            });
            foreach(Automation_Names automation_name in temp_LoginDataNames)
            {
                Temp_ListOfAutomationNames.Remove(automation_name);
            }


            ListOfPagesLogin = new ObservableCollection<Automation_Names>(temp_LoginDataNames);
            ListOfPagesData = new ObservableCollection<Automation_Names>(Temp_ListOfAutomationNames);


        }




       public  async Task Page_Loaded()
        {
            await  Task.Run(() =>
            {

                LoadAllPagesData();
            });
        }
    }
}
