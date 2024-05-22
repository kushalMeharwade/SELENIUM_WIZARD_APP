using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Models
{
    public class Element_Log:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string? _elementName;

        public string? elementName
        {
            get { return _elementName; }
            set { _elementName = value;OnPropertyChanged(nameof(elementName)); }
        }

        private bool _isSuccessfull=false;

        public bool isSuccessfull
        {
            get { return _isSuccessfull; }
            set { _isSuccessfull = value;OnPropertyChanged(nameof(isSuccessfull)); }
        }

        private string? _errorMessage;

        public string? errorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(errorMessage)); }
        }







    }
}
