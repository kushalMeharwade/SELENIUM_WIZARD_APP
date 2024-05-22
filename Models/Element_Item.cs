using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Models
{
    public class Element_Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private int _id;
        [Key]

        public int Id
        {
            get { return _id; }
            set { _id = value;OnPropertyChanged(nameof(Id)); }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;OnPropertyChanged(nameof(Name)); }
        }


        private int _PageCode;

        public int PageCode
        {
            get { return _PageCode; }
            set { _PageCode = value; OnPropertyChanged(nameof(PageCode)); }
        }


        private int _Order;

        public int Order
        {
            get { return _Order; }
            set { _Order = value; OnPropertyChanged(nameof(Order)); }
        }


        private string? _controlType;

        public string? controlType
        {
            get { return _controlType; }
            set { _controlType = value;OnPropertyChanged(nameof(controlType)); }
        }

        private string? _selectionType;

        public string? selectionType
        {
            get { return _selectionType; }
            set { _selectionType = value;OnPropertyChanged(nameof(selectionType)); }
        }

        private string? _selectorValue;

        public string? selectorValue
        {
            get { return _selectorValue; }
            set { _selectorValue = value;OnPropertyChanged(nameof(selectorValue)); }
        }




        private string? _method_ToExceute;

        public string? methodToExecute
        {
            get { return _method_ToExceute; }
            set { _method_ToExceute = value;OnPropertyChanged(nameof(methodToExecute)); }
        }



        private string? _sourceColumn;

        public string? sourceColumn
        {
            get { return _sourceColumn; }
            set { _sourceColumn = value;OnPropertyChanged(nameof(sourceColumn)); }
        }


        private bool _requiresInput;

        public bool requiresInput
        {
            get { return _requiresInput; }
            set { _requiresInput = value;OnPropertyChanged(nameof(requiresInput)); }
        }








    }
}
