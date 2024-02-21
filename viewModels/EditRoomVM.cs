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

namespace HotelPereMaria.viewModels
{
    public class EditRoomVM
    {
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
                string apiUrl = $"http://localhost:3000/api/rooms/{_selectedRoom.room_number}";

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
    }
}
