using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SunAndMoon.Model
{
    [XmlRoot("rss")]
    public class Rss
    {
        [XmlElement("channel")]
        public Channel Channel { get; set; }
    }

    public class Channel{

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("item")]
        public ObservableCollection<Item> Items {get; set;}

      
        public Channel(){
            this.Items = new ObservableCollection<Item>();
        }
    }

    public class Item{
          [XmlElement("title")]
        public string Title {get; set;}
          [XmlElement("link")]
        public string Link {get; set;}
          [XmlElement("image")]
        public string Image {get; set;}
    }
}
