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
        public int RoomNumber { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Price_per_night { get; set; }
        public int Rate { get; set; }
        public int MaxOccupancy { get; set; }
        public bool IsAvailable { get; set; }
        public string Image { get; set; }
    }
}
