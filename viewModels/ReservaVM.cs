using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace HotelPereMaria.viewModels
{
    class ReservaVM : INotifyPropertyChanged
    {
        private string _nombreCliente;
        private int _roomNumber;
        private DateTime _fechaEntrada;
        private DateTime _fechaSalida;
        private double _pricePerNight;
        private ObservableCollection<Extra> _extras;
        private User _user;
        public event PropertyChangedEventHandler PropertyChanged;


        public string NombreCliente
        {
            get { return _nombreCliente; }
            set
            {
                _nombreCliente = value;
                OnPropertyChanged(nameof(NombreCliente));
            }
        }

        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public DateTime FechaEntrada
        {
            get { return _fechaEntrada; }
            set
            {
                _fechaEntrada = value;
                OnPropertyChanged(nameof(FechaEntrada));
            }
        }

        public DateTime FechaSalida
        {
            get { return _fechaSalida; }
            set
            {
                _fechaSalida = value;
                OnPropertyChanged(nameof(FechaSalida));
            }
        }

        public double PricePerNight
        {
            get { return _pricePerNight; }
            set
            {
                _pricePerNight = value;
                OnPropertyChanged(nameof(PricePerNight));
            }
        }

        public ObservableCollection<Extra> Extras
        {
            get { return _extras; }
            set
            {
                _extras = value;
                OnPropertyChanged(nameof(Extras));
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CrearReservaCommand { get; }

        public ReservaVM(User currentUser)
        {
            CrearReservaCommand = new RelayCommand(CrearReserva);
        }

        private void CrearReserva(object parameter)
        {
            var reserva = new Reserva
            {
                NombreCliente = NombreCliente,
                RoomNumber = RoomNumber,
                FechaEntrada = FechaEntrada,
                FechaSalida = FechaSalida,
                PricePerNight = PricePerNight,
                Extras = Extras,
                User = User
            };

            var reservaJson = Newtonsoft.Json.JsonConvert.SerializeObject(reserva);
            Console.WriteLine(reservaJson);
        }

    }

    public class Extra
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int Phone { get; set; }
    }

    public class Reserva
    {
        public string NombreCliente { get; set; }
        public int RoomNumber { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public double PricePerNight { get; set; }
        public ObservableCollection<Extra> Extras { get; set; }
        public User User { get; set; }
    }

}
