using Windows.UI.Xaml.Media;
using Windows.UI;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
namespace Handasa_Map
{
    
    class Segment:IEquatable<Segment>,INotifyPropertyChanged
    {
        public string Name { get; set; }
        private SolidColorBrush _Color = null;
        public SolidColorBrush Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                if(PropertyChanged!=null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Color"));
            }
        }
        public Segment(string Name)
        {
            this.Name = Name;
            Color = new SolidColorBrush(Colors.DarkCyan);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Equals(Segment other)
        {
            return other.Name == this.Name;
        }
    }
}
