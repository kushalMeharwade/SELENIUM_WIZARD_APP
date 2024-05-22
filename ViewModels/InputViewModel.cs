using Selenium_Wizard.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Selenium_Wizard.ViewModels
{
   

    public class InputViewModel :INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string userInput;

        public string UserInput
        {
            get { return userInput; }
            set
            {
                if (userInput != value)
                {
                    userInput = value;
                    OnPropertyChanged(nameof(UserInput));
                }
            }
        }

        public ICommand SubmitCommand { get; }

        public InputViewModel(Action<object> onInputSubmitted)
        {
            SubmitCommand = new Command((s) =>true,onInputSubmitted);
        }
    }

}
