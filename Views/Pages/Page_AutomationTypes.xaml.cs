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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace Selenium_Wizard.Views.Pages
{
    /// <summary>
    /// Interaction logic for Page_AutomationTypes.xaml
    /// </summary>
    public partial class Page_AutomationTypes : UiPage
    {

        public ViewModels.ViewModel_Automation_Types ViewModel
        {
            get;
        }
        public Page_AutomationTypes(ViewModels.ViewModel_Automation_Types viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
            Loaded += async (sender, e) => await viewModel.Page_Loaded();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
