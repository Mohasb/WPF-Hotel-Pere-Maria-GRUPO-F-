using HotelPereMaria.models;
using HotelPereMaria.models.HotelPereMaria.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelPereMaria.viewModels
{

    public class ReservaVM : INotifyPropertyChanged
    {
        private UserModel _currentUser;
        public UserModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        private string _selectedRoomType;

        public string SelectedRoomType
        {
            get { return _selectedRoomType; }
            set
            {
                if (_selectedRoomType != value)
                {
                    _selectedRoomType = value;
                    OnPropertyChanged(nameof(SelectedRoomType));

                }
            }
        }
        private DateTime _fechaEntrada = DateTime.Today.AddDays(1);
        public DateTime FechaEntrada
        {
            get { return _fechaEntrada; }
            set
            {
                _fechaEntrada = value;
                OnPropertyChanged(nameof(FechaEntrada));
            }
        }

        private DateTime _fechaSalida = DateTime.Today.AddDays(1).AddDays(8);
        public DateTime FechaSalida
        {
            get { return _fechaSalida; }
            set
            {
                _fechaSalida = value;
                OnPropertyChanged(nameof(FechaSalida));
            }
        }

        private int _numeroHuespedes;
        public int NumeroHuespedes
        {
            get { return _numeroHuespedes; }
            set
            {
                _numeroHuespedes = value;
                OnPropertyChanged(nameof(NumeroHuespedes));
            }
        }

        private string _tipoHabitacion;
        public string TipoHabitacion
        {
            get { return _tipoHabitacion; }
            set
            {
                _tipoHabitacion = value;
                OnPropertyChanged(nameof(TipoHabitacion));
            }
        }

        private bool _wifiSelected = true;
        public bool WifiSelected
        {
            get { return _wifiSelected; }
            set
            {
                _wifiSelected = value;
                OnPropertyChanged(nameof(WifiSelected));
            }
        }

        private bool _allInclusiveSelected;
        public bool AllInclusiveSelected
        {
            get { return _allInclusiveSelected; }
            set
            {
                _allInclusiveSelected = value;
                OnPropertyChanged(nameof(AllInclusiveSelected));
            }
        }

        private bool _gymSelected;
        public bool GymSelected
        {
            get { return _gymSelected; }
            set
            {
                _gymSelected = value;
                OnPropertyChanged(nameof(GymSelected));
            }
        }

        private bool _spaSelected;
        public bool SpaSelected
        {
            get { return _spaSelected; }
            set
            {
                _spaSelected = value;
                OnPropertyChanged(nameof(SpaSelected));
            }
        }

        private bool _parkingSelected;
        public bool ParkingSelected
        {
            get { return _parkingSelected; }
            set
            {
                _parkingSelected = value;
                OnPropertyChanged(nameof(ParkingSelected));
            }
        }

        public ReservaVM(UserModel currentUser)
        {
            _currentUser = currentUser;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task<bool> makeReservation(DateTime fechaEntrada, DateTime fechaSalida, int numeroHuespedes, string tipoHabitacion, bool wifiSelected, bool allInclusiveSelected, bool gymSelected, bool spaSelected, bool parkingSelected)
        {

            int index = TipoHabitacion.IndexOf("Habitación");
            string room = TipoHabitacion.Substring(index + 10).Trim();


            PostReservation reservationData = new PostReservation
            {
                User = new User
                {
                    Name = CurrentUser.name,
                    Email = CurrentUser.email,
                    UserName = CurrentUser.user_name,
                    Role = CurrentUser.role,
                    Phone = int.Parse(CurrentUser.phone)
                },
                CheckInDate = fechaEntrada,
                CheckOutDate = fechaSalida,
                CancelationDate = DateTime.MinValue,
                RoomType = room,
                Ocupation = numeroHuespedes,
                Extras = new List<PostExtra>
                    {
                        new PostExtra { Name = "Completo", Value = allInclusiveSelected },
                        new PostExtra { Name = "Gym", Value = gymSelected },
                        new PostExtra { Name = "Spa", Value = spaSelected },
                        new PostExtra { Name = "Parking", Value = parkingSelected }
                    }
            };



            string jsonData = JsonConvert.SerializeObject(reservationData, Formatting.Indented);


            string apiUrl = "https://localhost/api/reservations";

            try
            {
                using HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;



                using (HttpClient client = new HttpClient(handler))
                {
                    string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImNvcnJlbzFAZXhhbXBsZS5jb20iLCJyb2xlIjoidXNlciIsImlhdCI6MTcwODI1ODAyOH0.MZk5APRdNL6B4p495PV8XoKnYhiOp-eXkgCw-DiVDSg";
                    client.DefaultRequestHeaders.Add("Authorization", token);

                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Reserva realizada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        return true;
                    }
                    else
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        dynamic result = JObject.Parse(responseBody);
                        MessageBox.Show($"{result.message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de solicitud HTTP: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
