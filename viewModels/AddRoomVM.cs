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
        private bool _gym;
        private bool _spa;
        private bool _parking;
        private bool _all;
        private double _pricePerNight;

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

        public double PricePerNight
        {
            get { return _pricePerNight; }
            set { _pricePerNight = value; OnPropertyChanged(nameof(PricePerNight)); }
        }
        // Add properties for other fields like RoomType, MaxOccupancy, Description, SelectedImage, Gym, Spa, Parking, All, PricePerNight

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

        private async void AddRoom(object parameter)
        {
            // Llamar al método AddRoom con la nueva habitación como parámetro
            await AddRoom(NewRoom);
        }

        public async Task AddRoom(RoomModel room)
        {
            try
            {
                string apiUrl = "https://localhost/api/rooms/";
                string token = "tu_token_de_autorizacion";

                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        httpClient.DefaultRequestHeaders.Add("Authorization", token);

                        string json = JsonConvert.SerializeObject(room);
                        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage responseMessage = await httpClient.PostAsync(apiUrl, content);

                        if (responseMessage.IsSuccessStatusCode)
                        {
                            // Habitación agregada exitosamente
                            MessageBox.Show("Habitación agregada exitosamente.");
                        }
                        else
                        {
                            // Manejar errores
                            string errorMessage = await responseMessage.Content.ReadAsStringAsync();
                            MessageBox.Show($"Error al agregar la habitación: {errorMessage}");
                        }
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
