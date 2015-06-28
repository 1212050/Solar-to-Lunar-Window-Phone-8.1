using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace SunAndMoon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            DrawerLayout.InitializeDrawerLayout();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DateSunTextBlock.Text = CustomDisplayDate(DemoDatePicker.Date.DateTime);
        }

        void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
            {
                DrawerLayout.CloseDrawer();
                e.Handled = true;
            }
            else
            {
                Application.Current.Exit();
            }
        }

        private void DrawerIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
                DrawerLayout.CloseDrawer();
            else
                DrawerLayout.OpenDrawer();
        }

        private async void Item1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var grid = sender as Grid;
            if (grid != null)
            {
                string menuItemName = grid.Name;
                MessageDialog dialog = null;
                CoreDispatcher dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
                switch (menuItemName)
                {
                    case "Item1":
                        DrawerLayout.CloseDrawer();
                        break;
                    case "Item2":
                        DrawerLayout.CloseDrawer();
                        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(Page2)));
                        break;
                    case "Item3":
                        await Windows.System.Launcher.LaunchUriAsync(new Uri("https://zing.vn/", UriKind.Absolute));
                        break;
                    case "Item4":
                        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => Frame.Navigate(typeof(Page3)));
                        break;
                }

                if (dialog != null) await dialog.ShowAsync();
            }
        }

        private void DemoDatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            DateSunTextBlock.Text = CustomDisplayDate(DemoDatePicker.Date.DateTime);
            DateMoonTextBlock.Text = "";
        }

        private void ResultButton_Click(object sender, RoutedEventArgs e)
        {
            DateSunTextBlock.Text = CustomDisplayDate(DemoDatePicker.Date.DateTime);
            DateTime d = DemoDatePicker.Date.DateTime;
            LunarDate ld = d.ToLunarDate();
            DateMoonTextBlock.Text = ld.ToString();
        }

        private String CustomDisplayDate(DateTime d)
        {
            return d.Day.ToString() + "/" + d.Month.ToString() + "/" + d.Year.ToString();
        }

        private void DateSunTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            DateMoonTextBlock.Text = "";
            DateSunTextBlock.Text = "";
        }
        
    }
}
