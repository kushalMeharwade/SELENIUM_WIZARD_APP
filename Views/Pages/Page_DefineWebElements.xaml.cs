using Selenium_Wizard.ViewModels;
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
using Wpf.Ui.Mvvm.Interfaces;

namespace Selenium_Wizard.Views.Pages
{
    /// <summary>
    /// Interaction logic for Page_DefineWebElements.xaml
    /// </summary>
    public partial class Page_DefineWebElements : UiPage
    {

        public ViewModels.ViewModel_DefineWebElements ViewModel
        {
            get;
        }


        public Page_DefineWebElements(ViewModel_DefineWebElements ViewModel)
        {
            this.DataContext = ViewModel;
            InitializeComponent();
            Loaded += async (sender, e) => await ViewModel.Page_Load();
        }
    }
}
