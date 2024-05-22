using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace Selenium_Wizard.Views.Windows
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : UiWindow
    {

       public string UserInput_Text { get; set; }
        public InputWindow()
        {
            
            InitializeComponent();
            
        }


        public string GetUserInput()
        {
            return UserInput_Text;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserInput_Text = UserInput.Text;
            Close();
        }

    }
}
