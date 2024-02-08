using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPereMaria.models
{
    public class RoomModel : INotifyPropertyChanged
    {
        public int _room_number {  get; set; }
        public string _type { get; set; }
        public string _description { get; set; }
        public double _price_per_night { get; set; }
        public int _rate { get; set; }
        public int _max_occupancy { get; set; }
        public Boolean _isAvailable { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
