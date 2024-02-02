using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;


namespace HotelPereMaria.VistaUser
{


    public class Reservation
    {
        public string _id { get; set; }
        public List<Extra> extras { get; set; }
        public User user { get; set; }
        public int room_number { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public double price_per_night { get; set; }
        public DateTime cancelation_date { get; set; }

        private static int _nextId = 1;

        public int ReservationId
        {
            get { return _nextId; }
            set { _nextId = value; }
        }
        public Reservation()
        {
            ReservationId = _nextId++;
        }

        public double TotalPrice
        {
            get
            {
                double extrasPrice = extras?.Sum(extra => extra.price) ?? 0;
                return price_per_night + extrasPrice;
            }
        }
    }

    public class Extra
    {
        public string name { get; set; }
        public double price { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public string role { get; set; }
        public string phone { get; set; }
    }




    class VistaUserModel : INotifyPropertyChanged
    {
        private string userId;
        private string userName;
        private string email;
        private string password;
        private string role;
        private ObservableCollection<Reservation> reservations;

        public event PropertyChangedEventHandler PropertyChanged;

        public VistaUserModel()
        {
            reservations = new ObservableCollection<Reservation>();
        }

        public VistaUserModel(string userId, string userName, string email, string password, string role, List<Reservation> reservations)
        {
            this.userId = userId;
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.role = role;
            this.reservations = new ObservableCollection<Reservation>(reservations);
        }

        public string UserId
        {
            get => userId;
            set
            {
                if (userId != value)
                {
                    userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        public string UserName
        {
            get => userName;
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string Role
        {
            get => role;
            set
            {
                if (role != value)
                {
                    role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        public ObservableCollection<Reservation> Reservations
        {
            get => reservations;
            set
            {
                if (reservations != value)
                {
                    reservations = value;
                    OnPropertyChanged(nameof(Reservations));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
