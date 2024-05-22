using Selenium_Wizard.Data;
using Selenium_Wizard.Data.Helpers;
using Selenium_Wizard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Selenium_Wizard.ViewModels
{
    public  class ViewModel_DefineWebElements:INotifyPropertyChanged
    {




        #region Commands

        public ICommand WebElementChanged { get; set; }
        public ICommand PageNameChanged { get; set; }
        public ICommand methodToExecuteChanged { get; set; }

        #endregion
        private ObservableCollection<Control_Type> _Control_Type_List = new ObservableCollection<Control_Type>();

        public ObservableCollection<Control_Type> Control_Type_List
        {
            get { return _Control_Type_List; }
            set { _Control_Type_List = new ObservableCollection<Control_Type>(value); OnPropertyChanged(nameof(Control_Type_List)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        private ObservableCollection<DropDownLIstItem> _ListOfDropDownItems=new ObservableCollection<DropDownLIstItem>();

        public ObservableCollection<DropDownLIstItem> ListOfDropDownItems
        {
            get { return _ListOfDropDownItems; }
            set { _ListOfDropDownItems= value;OnPropertyChanged(nameof(ListOfDropDownItems)); }
        }


       


        #region Command_Metodhs

        public void WeBElementChangedFunction(object s)
        {
            Control_Type Selected_Control_Type= Control_Type_List.ToList().Where(i=>i.Name==CurrentDbConnection.controlType).FirstOrDefault();
            if(Selected_Control_Type != null)
            {
                AvailableMethods = new ObservableCollection<string>(Selected_Control_Type.Available_Methods);
                AvailSelector = new ObservableCollection<string>(Selected_Control_Type.Selector_Types);

            }
         



        }

        public void methodToExecuteChangedFunction(object s)
        {
            string Selected_Method = CurrentDbConnection.methodToExecute;
            string[] array_of_click_events = { "submit" , "clear", "Click" };
            if (!String.IsNullOrEmpty(Selected_Method))
            {
                if (array_of_click_events.Contains(Selected_Method))
                {
                    CurrentDbConnection.sourceColumn = "-1";
                    CurrentDbConnection.Order = ListOfDbConnections.Count() + 1;
                    CurrentDbConnection.Name = String.Format("{0}_{1}_{2}", CurrentDbConnection.selectorValue, CurrentDbConnection.controlType, CurrentDbConnection.methodToExecute);
                }
                else
                {
                    CurrentDbConnection.Order = ListOfDbConnections.Count() + 1;
                    CurrentDbConnection.Name = String.Format("{0}_{1}_{2}", CurrentDbConnection.selectorValue, CurrentDbConnection.controlType, CurrentDbConnection.methodToExecute);
                }
            }

        }

        public void PageNameChangedFunction(object s)
        {
            Load_Connections();
        }




        #endregion
      


        private ObservableCollection<Automation_Names> _ListOfNames=new ObservableCollection<Automation_Names>();

        public ObservableCollection<Automation_Names> ListOfNames
        {
            get { return _ListOfNames; }
            set { _ListOfNames = value; OnPropertyChanged(nameof(ListOfNames)); }
        }


        private ObservableCollection<string> _AvailableMethods;     

        public ObservableCollection<string> AvailableMethods
        {
            get { return _AvailableMethods; }
            set { _AvailableMethods = value; OnPropertyChanged(nameof(AvailableMethods)); }
        }


        private ObservableCollection<string> _AvailSelector;

        public ObservableCollection<string> AvailSelector
        {
            get { return _AvailSelector; }
            set { _AvailSelector = value;OnPropertyChanged(nameof(AvailSelector)); }
        }



        private void LoadAllNames()
        {
            GenericDataService<Automation_Names> Automation_Name_DataService = new GenericDataService<Automation_Names>(new DbContextFactory());
            List<Automation_Names> Temp_Automation_Names = new List<Automation_Names>();
            Temp_Automation_Names = Automation_Name_DataService.GetAllNormal();
            ListOfNames =new ObservableCollection<Automation_Names>(Temp_Automation_Names);

        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void  Init_Control_Types()
        {
            // Form 

            List<Control_Type> Control_Type_List_Custom = new List<Control_Type>();

            Control_Type Control_Form = new Control_Type();
            Control_Form.Name = "Form_Element";
            Control_Form.Available_Methods.Add("Click");
            Control_Form.Available_Methods.Add("Enter");

            Control_Form.Selector_Types.Add("ById");
            Control_Form.Selector_Types.Add("ByClass");
            Control_Form.Selector_Types.Add("ByQuery");



            Control_Type_List_Custom.Add(Control_Form);


            // Button 


            Control_Type Control_Button = new Control_Type();
            Control_Button.Name = "Button_Element";
            Control_Button.Available_Methods.Add("Click");
            Control_Button.Available_Methods.Add("submit");
            Control_Button.Available_Methods.Add("clear");
            Control_Button.Available_Methods.Add("Enter");



            Control_Button.Selector_Types.Add("ById");
            Control_Button.Selector_Types.Add("ByClass");
            Control_Button.Selector_Types.Add("ByQuery");



            Control_Type_List_Custom.Add(Control_Button);


            // TextBox 


            Control_Type Control_TextBox = new Control_Type();
            Control_TextBox.Name = "TextBox_Element";
            Control_TextBox.Available_Methods.Add("sendKeys");
            Control_TextBox.Available_Methods.Add("clear");
            Control_TextBox.Available_Methods.Add("submit");
            Control_TextBox.Available_Methods.Add("Enter");


            Control_TextBox.Selector_Types.Add("ById");
            Control_TextBox.Selector_Types.Add("ByClass");
            Control_TextBox.Selector_Types.Add("ByQuery");



            Control_Type_List_Custom.Add(Control_TextBox);

            // DropDown 
            Control_Type Control_DropDown= new Control_Type();
            Control_DropDown.Name = "DropDown_Element";
            Control_DropDown.Available_Methods.Add("select_by_visible_text");
            Control_DropDown.Available_Methods.Add("select_by_value");
            Control_DropDown.Available_Methods.Add("select_by_index");
            Control_DropDown.Available_Methods.Add("get_first_selected_option");

          

            Control_DropDown.Selector_Types.Add("ById");
            Control_DropDown.Selector_Types.Add("ByClass");
            Control_DropDown.Selector_Types.Add("ByQuery");



            Control_Type_List_Custom.Add(Control_DropDown);




            // File Upload
            Control_Type Control_FileUpload = new Control_Type();
            Control_FileUpload.Name = "FileUpload_Element";
            Control_FileUpload.Available_Methods.Add("sendKeys");
        



            Control_FileUpload.Selector_Types.Add("ById");
            Control_FileUpload.Selector_Types.Add("ByClass");
            Control_FileUpload.Selector_Types.Add("ByQuery");



            Control_Type_List_Custom.Add(Control_FileUpload);


            // Redirect
            Control_Type Control_Redirect = new Control_Type();
            Control_Redirect.Name = "Redirect_Element";
            Control_Redirect.Available_Methods.Add("Redirect");




            Control_Redirect.Selector_Types.Add("ById");
            Control_Redirect.Selector_Types.Add("ByClass");
            Control_Redirect.Selector_Types.Add("ByQuery");



            Control_Type_List_Custom.Add(Control_Redirect);






            Control_Type Control_Delay = new Control_Type();
            Control_Delay.Name = "Delay_Element";
            Control_Delay.Available_Methods.Add("wait");




            Control_Delay.Selector_Types.Add("ById");
            Control_Delay.Selector_Types.Add("ByClass");
            Control_Delay.Selector_Types.Add("ByQuery");



            Control_Type_List_Custom.Add(Control_Delay);




            Control_Type_List = new ObservableCollection<Control_Type>(Control_Type_List_Custom);




        }


        public async Task Page_Load()
        {
            await Task.Run(() =>
            {
                Init_Control_Types();
                LoadAllNames();

              
                Application.Current.Dispatcher.InvokeAsync(async () =>
                {
                    ListOfDropDownItems.Add(new DropDownLIstItem("No", false));
                    ListOfDropDownItems.Add(new DropDownLIstItem("Yes", true));
                });

            });

        }




        private Element_Item _currentDbConnection = new Element_Item();
        private readonly GenericDataService<Element_Item> Repo_Connections;

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






        public ViewModel_DefineWebElements()
        {
            cmdAddButton = new Command((s) => true, Add_Record);
            Repo_Connections = new GenericDataService<Element_Item>(new DbContextFactory());

            cmdDeleteButton = new Command((s) => true, Delete_Record);
            cmdUpdateButton = new Command((s) => true, Update_Record);


            WebElementChanged = new Command((s) => true, WeBElementChangedFunction);
            PageNameChanged = new Command((s) => true, PageNameChangedFunction);
            methodToExecuteChanged = new Command((s) => true, methodToExecuteChangedFunction);


        }




        public void Message_Record(object sender, RoutedEventArgs a)
        {
            MessageBox.Show("HELLO");

        }




        public async void Load_Connections()
        {
            ObservableCollection<Element_Item> Temp = new ObservableCollection<Element_Item>();
            await Task.Run(() =>
            {
                isLoading = true;
                Temp = new ObservableCollection<Element_Item>(Repo_Connections.GetAllWithCondition(i=>i.PageCode==CurrentDbConnection.PageCode));
                isLoading = false;
            });

            ListOfDbConnections = Temp;
            OnPropertyChanged(nameof(ListOfDbConnections));
        }

        public Element_Item CurrentDbConnection
        {
            get => _currentDbConnection;
            set { _currentDbConnection = value; OnPropertyChanged(nameof(CurrentDbConnection)); }
        }

        private ObservableCollection<Element_Item> _ListOfDbConnections = new ObservableCollection<Element_Item>();



        public ObservableCollection<Element_Item> ListOfDbConnections
        {
            get { return _ListOfDbConnections; }
            set { _ListOfDbConnections = value; OnPropertyChanged(nameof(ListOfDbConnections)); }
        }


     


        private  void Update_Record(object s)
        {
            try
            {

                CurrentDbConnection = Repo_Connections.GetIntNormal(Convert.ToInt32(s!));
               

               


            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR : {ex.Message}");
            }

        }

        private async void Add_Record(object s)
        {

            await Task.Run(() =>
            {

                Element_Item TempRecord = new Element_Item();
                int PageCode = 0;
                int OrderNum = 0;

                try
                {
                    if (CurrentDbConnection.Id == 0)
                    {
                        PageCode = CurrentDbConnection.PageCode;
                        OrderNum = CurrentDbConnection.Order + 1;
                        TempRecord =  Repo_Connections.Create(CurrentDbConnection).Result;
                        MessageBox.Show("RECORD ADDED SUCCESSFULLY");
                    }

                    else
                    {
                        PageCode = CurrentDbConnection.PageCode;
                        OrderNum = CurrentDbConnection.Order + 1;
                        TempRecord =  Repo_Connections.Update(CurrentDbConnection).Result;
                        MessageBox.Show("RECORD UPDATED SUCCESSFULLY");

                    }

                     Application.Current.Dispatcher.InvokeAsync(async () =>
                    {
                        ListOfDbConnections.Add(TempRecord);
                    });
               

                    CurrentDbConnection = new Element_Item();
                    CurrentDbConnection.PageCode = PageCode;
                    CurrentDbConnection.Order = OrderNum;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR : {ex.Message}");
                }

            });
          








        }



        public async Task Page_Loaded()
        {
            await Task.Run(() =>
            {

                

            });
        }

        private async void Delete_Record(object s)
        {
            try
            {
                bool is_File_Deleted = false;
                int Record_Id = Convert.ToInt32(s);
                Element_Item TypeObject = await Repo_Connections.GetInt(Record_Id);
                is_File_Deleted = await Repo_Connections.Delete(TypeObject);
                if (is_File_Deleted)
                {
                    MessageBox.Show("RECORD DELETED SUCCESSFULLY");
                    Element_Item? Temp_Record = ListOfDbConnections.FirstOrDefault(x => x.Id == Record_Id);
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
