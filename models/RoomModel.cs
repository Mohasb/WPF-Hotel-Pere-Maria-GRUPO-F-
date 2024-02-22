using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPereMaria.models
{
    public class RoomModel
    {
        public string _id { get; set; }
        public int room_number { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public List<Image> images { get; set; }
        public double price_per_night { get; set; }
        public int rate { get; set; }
        public int max_occupancy { get; set; }
        public bool isAvailable { get; set; }
    }

    public class Image
    {
        public string _id { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }
}
