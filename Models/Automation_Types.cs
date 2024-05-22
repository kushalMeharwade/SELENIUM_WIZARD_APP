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
    public class Automation_Types : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private int _Id;
        [Key]
        public int ID
        {
            get { return _Id; }
            set { _Id = value;OnPropertyChanged(nameof(ID)); }
        }


        private string? _typeName;

        public string? typeName
        {
            get { return _typeName; }
            set { _typeName = value;OnPropertyChanged(nameof(typeName)); }
        }

        public override string ToString()
        {
            return this.typeName ?? string.Empty;
        }


    }
}
