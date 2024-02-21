using HotelPereMaria.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace HotelPereMaria.viewModels
{
    public class EditRoomVM
    {
        public ObservableCollection<RoomModel> Rooms { get; } = new ObservableCollection<RoomModel>();
        private RoomModel _selectedRoom;

        public RoomModel SelectedRoom
        {
            get { return _selectedRoom; }
            set { _selectedRoom = value; }
        }

        private int _selectedRoomNumber;
        public int SelectedRoomNumber
        {
            get { return _selectedRoomNumber; }
            set
            {
                _selectedRoomNumber = value;
                //OnPropertyChanged(nameof(SelectedRoomNumber));
            }
        }
        public ICommand SaveRoomCommand { get; set; }

        public EditRoomVM(int roomNumber)
        {
            SelectedRoom = new RoomModel();
            SelectedRoom.room_number = roomNumber;
            //SaveRoomCommand = new RelayCommand(async () => await SaveRoomAsync(roomNumber), () => true);
        }

        private async Task SaveRoomAsync(int room_number)
        {
            try
            {
                if (_selectedRoom == null)
                {
                    MessageBox.Show("No se ha seleccionado ninguna habitación para guardar.");
                    return;
                }

                using HttpClient client = new HttpClient();
                string apiUrl = $"http://localhost:3000/api/rooms/room/{_selectedRoom.room_number}";

                var jsonContent = JsonConvert.SerializeObject(_selectedRoom);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PatchAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Habitación actualizada correctamente.");
                }
                else
                {
                    MessageBox.Show($"Error al actualizar la habitación. Código de estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public async Task LoadRoomsByNumber(int room_number, string userEmail = "correo1@example.com")
        {
            try
            {
                string apiUrl = $"http://localhost:3000/api/rooms/room/{room_number}";
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTcwODAxMTc5MCwiZXhwIjoxNzM5NTY5MzkwfQ.-ycLIEcnpQGrb-JnYA_RjRHy0qtJ_L3uxtSEIoQhp4E";

                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        httpClient.DefaultRequestHeaders.Add("Authorization", token);

                        HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl);

                        if (responseMessage.IsSuccessStatusCode)
                        {
                            string json = await responseMessage.Content.ReadAsStringAsync();
                            List<RoomModel> rooms = JsonConvert.DeserializeObject<List<RoomModel>>(json);

                            Rooms.Clear();
                            //var rooms = await responseMessage.Content.ReadAsStringAsync();
                            foreach (var room in rooms)
                            {
                                Rooms.Add(room);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al traer habitacion por numero: {ex.Message}");
            }
        }
    }
}
