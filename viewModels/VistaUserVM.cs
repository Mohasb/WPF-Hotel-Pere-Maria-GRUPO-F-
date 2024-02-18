using HotelPereMaria.models;
using HotelPereMaria.viewModels;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelPereMaria.VistaUser
{
    public class VistaUserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ReservaModel> _reservations;
        private ObservableCollection<UserModel> _users;
        private UserModel _currentUser;

        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(param => DeleteReservationAndApiAsync((ReservaModel)param), param => true);
                }
                return _deleteCommand;
            }
        }

        private bool _isDataGridVisible;

        public bool IsDataGridVisible
        {
            get { return _isDataGridVisible; }
            set
            {
                _isDataGridVisible = value;
                OnPropertyChanged(nameof(IsDataGridVisible));
            }
        }




        private void DeleteReservation(ReservaModel reservation)
        {
            if (reservation != null)
            {
                int index = Reservations.IndexOf(reservation);
                if (index != -1)
                {
                    Reservations.RemoveAt(index);
                }
            }
        }

        private async Task DeleteReservationAndApiAsync(ReservaModel reservation)
        {
            // Confirmar con el usuario antes de eliminar
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta reserva?", "Confirmación", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                int reservationIndex = reservation.ReservationId - 1;

                // Eliminar la reserva de la colección local
                DeleteReservation(reservation);

                // Eliminar la reserva de la API utilizando el índice
                if (reservation != null)
                {
                    if (reservationIndex >= 0 && reservationIndex < Reservations.Count)
                    {
                        await DeleteReservationApiAsync(reservation.user.email, reservationIndex);
                    }
                    else
                    {
                        MessageBox.Show("Error: Índice de reserva no válido");
                    }
                }
            }
        }

        private async Task DeleteReservationApiAsync(string userEmail, int reservationIndex)
        {
            try
            {
                string apiUrl = $"https://localhost/api/reservations/{userEmail}/{reservationIndex}";

                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient client = new HttpClient(handler))
                    {
                        HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Error: {response.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        public UserModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        public ObservableCollection<ReservaModel> Reservations
        {
            get { return _reservations; }
            set
            {
                if (_reservations != value)
                {
                    _reservations = value;
                    OnPropertyChanged(nameof(Reservations));
                }
            }
        }

        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        public async Task LoadReservations(string userEmail)
        {
            try
            {
                string apiUrl = $"https://localhost/api/reservations/{userEmail}";

                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient client = new HttpClient(handler))
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            var reservations = JsonConvert.DeserializeObject<ObservableCollection<ReservaModel>>(json);

                            Reservations = reservations;

                            if (reservations.Count > 0)
                            {
                                CurrentUser = reservations[0].user;
                            }
                            // Asignar id basado en el índice
                            for (int i = 0; i < reservations.Count; i++)
                            {
                                reservations[i].ReservationId = i + 1;
                                reservations[i].check_in_date = new DateTime(reservations[i].check_in_date.Year, reservations[i].check_in_date.Month, reservations[i].check_in_date.Day, 12, 0, 0);
                                reservations[i].check_out_date = new DateTime(reservations[i].check_out_date.Year, reservations[i].check_out_date.Month, reservations[i].check_in_date.Day, 14, 0, 0);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Error: {response.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public async Task LoadUsers()
        {
            try
            {
                string apiUrl = $"https://localhost/api/users/";
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1oQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTcwODAxMjgzOCwiZXhwIjoxNzM5NTcwNDM4fQ.AFJvP5VVs04zQ8w9pxSYZF9gYA6nnVZol8hMUy92oRc";

                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient client = new HttpClient(handler))
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            var users = JsonConvert.DeserializeObject<ObservableCollection<UserModel>>(json);

                            Users = users;
                        }
                        else
                        {
                            MessageBox.Show($"Error: {response.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
