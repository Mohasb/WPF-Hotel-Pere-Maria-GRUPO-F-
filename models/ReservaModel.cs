﻿using HotelPereMaria.viewModels;
using HotelPereMaria.VistaUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace HotelPereMaria.models
{


    public class ReservaModel : INotifyPropertyChanged
    {
        public string _id { get; set; }
        public List<Extra> extras { get; set; }
        public User user { get; set; }
        public int room_number { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public double price_per_night { get; set; }
        public DateTime cancelation_date { get; set; }

        private int reservationId;

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

        public void Reservation(int reservationIndex)
        {
            ReservationId = reservationIndex + 1;
        }

        public double TotalPrice
        {
            get
            {
                double extrasPrice = extras?.Sum(extra => extra.price) ?? 0;
                return price_per_night + extrasPrice;
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
