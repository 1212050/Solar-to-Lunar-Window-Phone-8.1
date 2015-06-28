using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunAndMoon.Model;
using System.Net.Http;
using System.Xml.Serialization;
using System.ComponentModel;

namespace SunAndMoon.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private Rss _rss;

        public Rss Rss { 
            get {
                return this._rss;
            }
            set {
                this._rss = value;
                NotifyPropertyChanged("Rss");
            }
        }

        public bool IsLoaded { get; set; }

        public async void LoadRss(string url)
        {
            HttpClient client = new HttpClient();
            using (var stream = await client.GetStreamAsync(url))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Rss));
                this.Rss = serializer.Deserialize(stream) as Rss;
                IsLoaded = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
