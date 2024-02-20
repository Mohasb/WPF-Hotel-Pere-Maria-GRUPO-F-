using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPereMaria.models
{
    public class RoomModel :INotifyPropertyChanged
    {
        public string __id { get; set; }
        public int _room_number { get; set; }
        public string _type { get; set; }
        public string _description { get; set; }
        public List<String> _images { get; set; }
        public double _price_per_night { get; set; }
        public int _rate { get; set; }
        public int _max_occupancy { get; set; }
        public bool _isAvailable { get; set; }

        public String _Id
        {
            get { return __id; }
            set
            {
                if (__id != value)
                {
                    __id = value;
                    OnPropertyChanged(nameof(_Id));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   
}
