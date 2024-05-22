using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Models
{
     public class Page_Execute:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private string? _baseUrl;

        public string baseUrl
        {
            get { return _baseUrl!; }
            set { _baseUrl = value;OnPropertyChanged(nameof(baseUrl)); }
        }


        private string? _FilePath_1;

        public string? FIlePath_1
        {
            get { return _FilePath_1; }
            set { _FilePath_1 = value;OnPropertyChanged(nameof(FIlePath_1)); }
        }

        private string? _FilePath_2;

        public string? FIlePath_2
        {
            get { return _FilePath_2; }
            set { _FilePath_2 = value; OnPropertyChanged(nameof(FIlePath_2)); }
        }


        private int _LoginPageCode;

        public int LoginPageCode
        {
            get { return _LoginPageCode; }
            set { _LoginPageCode = value;OnPropertyChanged(nameof(LoginPageCode)); }
        }


        private int _dataPageCode;

        public int dataPageCode
        {
            get { return _dataPageCode; }
            set { _dataPageCode = value;OnPropertyChanged(nameof(dataPageCode)); }
        }








    }
}
