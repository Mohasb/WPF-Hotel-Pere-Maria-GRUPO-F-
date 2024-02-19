using HotelPereMaria.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelPereMaria.viewModels
{
    public class AddRoomVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _roomNumber;
        private string _roomType;
        private int _maxOccupancy;
        private string _description;
        private string _selectedImage;
        private int _rate;

        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        public string RoomType
        {
            get { return _roomType; }
            set { _roomType = value; OnPropertyChanged(nameof(RoomType));}
        }

        public int MaxOccupancy
        {
            get { return _maxOccupancy; }
            set
            {
                _maxOccupancy = value; OnPropertyChanged(nameof(MaxOccupancy));
            }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }
        public string SelectedImage
        {
            get => _selectedImage;
            set { }
        }

        public int Rate
        {
            get { return _rate; }
            set { _rate = value; OnPropertyChanged(nameof(Rate)); }
        }

        public ObservableCollection<int> MaxOccupancyOptions { get; set; }

        public ICommand AddRoomCommand { get; set; }
        public RoomModel NewRoom { get; set; }

        public AddRoomVM()
        {
            NewRoom = new RoomModel();
        }

        private bool CanAddRoom(object parameter)
        {
            // Add validation logic here
            return true;
        }

        public async Task AddRoom(dynamic room)
        {
            try
            {
                using HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                string apiUrl = "https://localhost/api/rooms/";
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTcwODM1NzQ4MH0.q_bdoxS8fe3mGf7YQ97P35v3Q3DIshs1MotPMf3od6k";

                using (var httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);

                    var jsonContent = JsonConvert.SerializeObject(room);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Habitación añadida correctamente.");
                        //txtRoomNumber.Text = string.Empty;
                        //txtRoomType.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show($"Error al añadir la habitación. Código de estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
