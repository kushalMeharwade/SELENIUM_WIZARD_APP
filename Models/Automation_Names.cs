using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Wizard.Models
{
    public  class Automation_Names : INotifyPropertyChanged
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

        private int _typeCode;

        public int typeCode
        {
            get { return _typeCode; }
            set { _typeCode = value;OnPropertyChanged(nameof(typeCode)); }
        }


        private string? _typeName;

        public string? typeName
        {
            get { return _typeName; }
            set { _typeName = value;OnPropertyChanged(nameof(typeName)); }
        }



        private string? _Name;

        public string? Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(nameof(Name)); }
        }


        public override string ToString()
        {
            return this.Name ?? string.Empty;
        }





    }
}
