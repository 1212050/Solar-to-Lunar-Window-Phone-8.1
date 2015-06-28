using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SunAndMoon.Model;
using SunAndMoon.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SunAndMoon
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page3 : Page
    {
        private MainViewModel model;
        public Page3()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            model = new MainViewModel();
            this.DataContext = model;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!model.IsLoaded)
            {
                model.LoadRss("http://vietnamnet.vn/rss/moi-nong.rss");
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListNews.SelectedIndex != null)
            {
                Item item = ListNews.SelectedItem as Item;
                Frame.Navigate(typeof(ReadView), item);
            }
        }
    }
}
