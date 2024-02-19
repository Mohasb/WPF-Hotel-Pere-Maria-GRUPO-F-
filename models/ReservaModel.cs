using HotelPereMaria.viewModels;
using HotelPereMaria.VistaUser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace HotelPereMaria.models
{


    public class ReservaModel : INotifyPropertyChanged
    {
        public List<Extra> extras { get; set; }
        public UserModel user { get; set; }
        public int room_number { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public double price_per_night { get; set; }
        public DateTime cancelation_date { get; set; }
        public Double total_price { get; set; }

        private int reservationId;
        [JsonProperty("_id")]
        public string Id { get; set; }

        public string roomType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public int ReservationId
        {
            get { return reservationId; }
            set
            {
                if (reservationId != value)
                {
                    reservationId = value;
                    OnPropertyChanged(nameof(ReservationId));
                }
            }
        }

  


        public string RoomType
        {
            get { return roomType; }
            set
            {
                if (roomType != value)
                {
                    roomType = value;
                    OnPropertyChanged(nameof(RoomType));
                }
            }
        }

        public void Reservation(int reservationIndex)
        {
            ReservationId = reservationIndex + 1;
        }

        public double TotalPrice
        {
            get
            {
                return total_price;
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Extra
    {
        public string name { get; set; }
        public double price { get; set; }
    }

}
