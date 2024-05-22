using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.DOM;
using OpenQA.Selenium.Support.UI;
using Selenium_Wizard.Models;
using Selenium_Wizard.ViewModels;
using Selenium_Wizard.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Selenium_Wizard.Helpers
{
    public  class SeleniumHelper
    {
        static IWebDriver Driver;
        static WebDriverWait Driver_Wait;
        static ChromeOptions chromeOptions = new ChromeOptions();


        public SeleniumHelper()
        {
            Driver = new ChromeDriver(chromeOptions);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Driver_Wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, TimeSpan.FromSeconds(5000));

            chromeOptions.AddArguments("--start-maximized");

            chromeOptions.AddArguments("disable-extensions");

            chromeOptions.AddArguments("disable-popup-blocking");

            chromeOptions.AddArguments("--disable-notifications");
        }


        public IWebElement? GetElement(Element_Item item)
        {
            IWebElement? webElemnt;
            if(item.controlType== "Redirect_Element" || item.controlType== "Delay_Element")
            {
                webElemnt = Driver.FindElement(By.CssSelector("body"));
            }
            else
            {
                switch (item.selectionType)
                {
                    case "ById":
                        webElemnt = Driver.FindElement(By.Id(item.selectorValue));
                        break;
                    case "ByClass":
                        webElemnt = Driver.FindElement(By.ClassName(item.selectorValue));

                        break;
                    case "ByQuery":
                        webElemnt = Driver.FindElement(By.CssSelector(item.selectorValue));

                        break;
                    default:
                        webElemnt = Driver.FindElement(By.CssSelector(item.selectorValue));

                        break;

                }
            }
         

            return webElemnt;
        }


        public SelectElement? GetElementSelect (Element_Item item)
        {
            SelectElement? webElemnt;
            if (item.controlType == "Redirect_Element" || item.controlType == "Delay_Element")
            {
                webElemnt = new SelectElement(Driver.FindElement(By.CssSelector("body")));
            }
            else
            {
                switch (item.selectionType)
                {
                    case "ById":
                        webElemnt = new SelectElement(Driver.FindElement(By.Id(item.selectorValue)));
                        break;
                    case "ByClass":
                        webElemnt = new SelectElement(Driver.FindElement(By.ClassName(item.selectorValue)));

                        break;
                    case "ByQuery":
                        webElemnt = new SelectElement(Driver.FindElement(By.CssSelector(item.selectorValue)));

                        break;
                    default:
                        webElemnt = new SelectElement(Driver.FindElement(By.CssSelector(item.selectorValue)));

                        break;

                }
            }


            return webElemnt;
        }



        public void ExecuteMethod(IWebElement webElement, string method,DataRow dataRow,Element_Item item)
        {

            if (item.requiresInput)
            {
                
                InputWindow inputWindow = new InputWindow();
                inputWindow.Topmost = true;
                inputWindow.ShowDialog();
                item.sourceColumn = inputWindow.GetUserInput();

            }
           

          


            switch (method)
            {
                case "sendKeys":
                    if (item.requiresInput)
                    {
                        webElement.SendKeys(item.sourceColumn.ToString());

                    }
                    else
                    {
                        if (dataRow.Table.Columns.Contains(item.sourceColumn))
                        {
                            webElement.SendKeys(dataRow[item.sourceColumn].ToString());

                        }
                        else
                        {
                            throw new Exception(String.Format("INVALID SOURCE COLUMN, EXCEL DOES NOT CONTAIN COLUMN {0}", item.sourceColumn));

                        }
                    }
                  

                    break;

                case "clear":
                    webElement.Clear();
                    break;
                case "submit":
                    webElement.Submit();
                    break;
                case "Enter":
                    webElement.SendKeys(Keys.Enter);
                    break;
                case "Redirect":
                    Driver.Navigate().GoToUrl(item.selectorValue);
                    break;
                case "select_by_visible_text":
                   
                    SelectElement select_item = webElement as SelectElement;
                    select_item.DeselectAll();
                    select_item.SelectByText(dataRow[item.sourceColumn].ToString());

                    break;
                case "select_by_value":
                    select_item = webElement as SelectElement;
                    select_item.DeselectAll();
                    select_item.SelectByValue(dataRow[item.sourceColumn].ToString());
                    break;
                case "select_by_index":
                    select_item = webElement as SelectElement;
                    select_item.DeselectAll();
                    select_item.SelectByIndex(Convert.ToInt32(dataRow[item.sourceColumn].ToString()));
                    break;
                case "get_first_selected_option":
                    select_item = webElement as SelectElement;
                    select_item.DeselectAll();
                    select_item.SelectByIndex(0);
                    break;
                case "wait":
                    Thread.Sleep(Convert.ToInt32(dataRow[item.sourceColumn].ToString()));
                    break;


            }

        }


        public void ExecuteMethod(SelectElement webElement, string method, DataRow dataRow, Element_Item item)
        {

            if (item.requiresInput)
            {

                InputWindow inputWindow = new InputWindow();
                inputWindow.Topmost = true;
                inputWindow.ShowDialog();
                item.sourceColumn = inputWindow.GetUserInput();

            }





            switch (method)
            {
              

             
                case "select_by_visible_text":

                    SelectElement select_item = webElement as SelectElement;
                    select_item.DeselectAll();
                    select_item.SelectByText(dataRow[item.sourceColumn].ToString());

                    break;
                case "select_by_value":
                    select_item = webElement as SelectElement;
                  
                    select_item.SelectByValue(dataRow[item.sourceColumn].ToString());
                    break;
                case "select_by_index":
                    select_item = webElement as SelectElement;
                    
                    select_item.SelectByIndex(Convert.ToInt32(dataRow[item.sourceColumn]));
                    break;
                case "get_first_selected_option":
                    select_item = webElement as SelectElement;
                  
                    select_item.SelectByIndex(0);
                    break;
                case "wait":
                    Thread.Sleep(Convert.ToInt32(item.sourceColumn));
                    break;


            }

        }

        public void EachItemExecutation(Element_Item item,DataRow Row_CollectionOfData,Element_Log element_Log)
        {
            try
            {
                element_Log.elementName= item.Name;
                element_Log.isSuccessfull = true;

                IWebElement? WebElement = GetElement(item);
                if(WebElement != null ) {
                    if(item.controlType== "DropDown_Element")
                    {
                        SelectElement itemDropDown = GetElementSelect(item);
                        ExecuteMethod(itemDropDown, item.methodToExecute, Row_CollectionOfData, item);

                    }
                    else
                    {
                        ExecuteMethod(WebElement, item.methodToExecute, Row_CollectionOfData, item);

                    }
                }
                else
                {
                    throw new Exception(String.Format("ELEMENT NOT FOUND : {0} : {1}", item.selectionType, item.selectorValue)) ;
                }

                element_Log.isSuccessfull = true;

            }
            catch(Exception ex)
            {
                element_Log.isSuccessfull = false;
                element_Log.errorMessage = ex.Message;

            }
        }

        public void IterateMethodsAndExecute(List<Element_Item> ListOfItems,DataTable dt,string baseUrl,ObservableCollection<Element_Log> elementLogs,int CurrentValue)
        {
             
           
              for(int i = 0; i < dt.Rows.Count; i++)
              {
                try
                {
                    for(int j = 0; j < ListOfItems.Count; j++)
                    {
                        Element_Log NewLogElement = new Element_Log();
                        EachItemExecutation(ListOfItems[j] as Element_Item, dt.Rows[i], NewLogElement);
                        elementLogs.Add(NewLogElement);
                       
                        
                    }
                    CurrentValue = i;
                }
                catch (Exception)
                {
                    CurrentValue = i;
                }
            }
        }


        public void IterateMethodsAndExecuteLogin(List<Element_Item> ListOfItems, DataTable dt, string baseUrl, ObservableCollection<Element_Log> elementLogs, int CurrentValue)
        {
            Driver.Navigate().GoToUrl(baseUrl);

            for (int i = 0; i < 1; i++)
            {
                try
                {
                    for (int j = 0; j < ListOfItems.Count; j++)
                    {
                        Element_Log NewLogElement = new Element_Log();
                        EachItemExecutation(ListOfItems[j] as Element_Item, dt.Rows[i], NewLogElement);
                        elementLogs.Add(NewLogElement);


                    }
                    CurrentValue = i;
                }
                catch (Exception)
                {
                    CurrentValue = i;
                }
            }
        }

    }
}
