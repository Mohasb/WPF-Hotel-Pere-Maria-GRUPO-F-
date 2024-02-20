using HotelPereMaria.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace HotelPereMaria.viewModels
{
    public class RoomVM
    {
        public ObservableCollection<RoomModel> Rooms { get; } = new ObservableCollection<RoomModel>();

        public async Task LoadRooms(string userEmail = "correo1@example.com")
        {
            try
            {
                string apiUrl = $"http://localhost:3000/api/rooms/unique-rooms";
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
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }


    
}
