using HotelPereMaria.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelPereMaria.viewModels
{
    public class RoomDetailsVM : INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient = new HttpClient();
        //public Api api
        private List<RoomModel> _allRooms;
        public ICommand DetailsRoomCommand { get;}
        public ICommand UpdateRoomCommand { get;} 
        public ICommand DeleteRoomCommand { get;}
        private int _selectedRoom;

        public int SelectedRoom
        {
            get {
                return _selectedRoom;
           
            }
            set
            {
                _selectedRoom = value;
                OnPropertyChanged(nameof(SelectedRoom));
            }
        }

        public List<RoomModel> AllRooms
        {
            get { return _allRooms; }
            set
            {
                _allRooms = value;
                OnPropertyChanged();
            }
        }

        public RoomDetailsVM()
        {
            DetailsRoomCommand = new RelayCommand(param => GetRoomDetails());
            UpdateRoomCommand = new RelayCommand(param => UpdateRoom());
            DeleteRoomCommand = new RelayCommand(param => DeleteRoom());
        }

        private async Task DeleteRoom()
        {
            try
            {
                string apiURL = $"http://localhost:3000/api/rooms/{SelectedRoom}";
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTcwODU0MDY5Nn0.v4gtTC0CTmI2crZitB5L_RVfvfTC1tyZKznIImxzOAs";
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient client = new HttpClient(httpClientHandler))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", token);
                        HttpResponseMessage response = await client.DeleteAsync(apiURL);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Habitación eliminada correctamente");
                        }
                        else
                        {
                            MessageBox.Show($"{response.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task UpdateRoom()
        {
            try
            {
                string apiURL = $"http://localhost:3000/api/rooms/{SelectedRoom}";
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTcwODU0MDY5Nn0.v4gtTC0CTmI2crZitB5L_RVfvfTC1tyZKznIImxzOAs";

                var data = new
                {
                    type = Type,
                    room_number = RoomNumber,
                    description = Description,
                    rate = Rate,
                    max_occupancy = Max_occupancy
                };
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    var request = new HttpRequestMessage(new HttpMethod("PATCH"), apiURL)
                    {
                        Content = content
                    };

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Habitación actualizada correctamente");
                    }
                    else
                    {
                        MessageBox.Show($"{response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        
        private async Task GetRoomDetails()
        {
            foreach(var room in _allRooms)
            {
                if( SelectedRoom == room.room_number )
                {
                    Type = room.type;
                    RoomNumber = room.room_number;
                    Description = room.description;
                    Rate = room.rate;
                    Max_occupancy = room.max_occupancy;
                }
            }
            
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        private int _room_number;
        public int RoomNumber
        {
            get { return _room_number; }
            set { _room_number = value; OnPropertyChanged(); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }


        private int _rate;
        public int Rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                OnPropertyChanged();
            }
        }

        private int _max_occupancy;
        private object parametro;

        public int Max_occupancy
        {
            get { return _max_occupancy; }
            set
            {
                _max_occupancy = value;
                OnPropertyChanged();
            }
        }
       


        public async Task GetRooms()
        {
            try
            {
                string apiURL = $"http://localhost:3000/api/rooms";
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTcwODU0MDY5Nn0.v4gtTC0CTmI2crZitB5L_RVfvfTC1tyZKznIImxzOAs";
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient client = new HttpClient(httpClientHandler))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", token);
                        HttpResponseMessage response = await client.GetAsync(apiURL);
                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            AllRooms = JsonConvert.DeserializeObject<List<RoomModel>>(json);
                            //AllRooms = JsonConvert.DeserializeObject<RoomModel>(json);
                        }
                        else
                        {
                            MessageBox.Show($"{response.StatusCode}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
