using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace Selenium_Wizard.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();

        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "SELENIUM TEST PRO";

            NavigationItems = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "TYPES",
                    PageTag = "TYPES",
                    Icon = SymbolRegular.Home24,
                    PageType = typeof(Views.Pages.Page_AutomationTypes)
                },
                new NavigationItem()
                {
                    Content = "NAMES",
                    PageTag = "NAMES",
                    Icon = SymbolRegular.DataHistogram24,
                    PageType = typeof(Views.Pages.Page_Names)
                }
                , new NavigationItem()
                {
                    Content = "DEFINE ELEMENTS",
                    PageTag = "ELEMENTS",
                    Icon = SymbolRegular.DataHistogram24,
                    PageType = typeof(Views.Pages.Page_DefineWebElements)
                }

                  , new NavigationItem()
                {
                    Content = "EXECUTE",
                    PageTag = "EXECUTE",
                    Icon = SymbolRegular.Play12,
                    PageType = typeof(Views.Pages.Page_Execute)
                }
            };

            NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Settings",
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings24,
                    PageType = typeof(Views.Pages.SettingsPage)
                }
            };

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "Home",
                    Tag = "tray_home"
                }
            };

            _isInitialized = true;
        }
    }
}
