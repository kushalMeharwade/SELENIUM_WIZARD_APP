using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Models
{
    public class DropDownLIstItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private string? _text;

        public string? text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(nameof(text)); }
        }

        private bool _selectedValue;

        public bool selectedValue
        {
            get { return _selectedValue; }
            set { _selectedValue = value; OnPropertyChanged(nameof(selectedValue)); }
        }

        public DropDownLIstItem(string text,bool passedvalue)
        {
            this.text = text;
            this.selectedValue = passedvalue;
        }


    }
}
