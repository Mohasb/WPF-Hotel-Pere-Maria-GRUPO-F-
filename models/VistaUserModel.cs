using HotelPereMaria.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;


namespace HotelPereMaria.VistaUser
{
    class VistaUserModel : INotifyPropertyChanged
    {
        private string userId;
        private string userName;
        private string email;
        private string password;
        private string role;
        private string telefono;
        private ObservableCollection<ReservaModel> reservations;

        public event PropertyChangedEventHandler PropertyChanged;

        public VistaUserModel()
        {
            reservations = new ObservableCollection<ReservaModel>();
        }

        public VistaUserModel(string telefono,string userId, string userName, string email, string password, string role, List<ReservaModel> reservations)
        {
            this.userId = userId;
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.role = role;
            this.telefono = telefono;
            this.reservations = new ObservableCollection<ReservaModel>(reservations);
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
        public string Telefono
        {
            get => telefono;
            set
            {
                if (telefono != value)
                {
                    telefono = value;
                    OnPropertyChanged(nameof(Telefono));
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

        public ObservableCollection<ReservaModel> Reservations
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
