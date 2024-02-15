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
                string apiUrl = $"https://localhost/api/rooms/";
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsImlhdCI6MTcwODAxMTc5MCwiZXhwIjoxNzM5NTY5MzkwfQ.-ycLIEcnpQGrb-JnYA_RjRHy0qtJ_L3uxtSEIoQhp4E";

                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {
                        httpClient.DefaultRequestHeaders.Add("Authorization", token);  //.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl);

                        if (responseMessage.IsSuccessStatusCode)
                        {
                            var rooms = await responseMessage.Content.ReadAsStringAsync();
                            foreach (var room in rooms)
                            {
                                //Rooms.Add(room);
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
        //public async Task LoadRooms(string userEmail = "correo1@example.com")
        //{
        //    try
        //    {
        //        string apiUrl = $"https://localhost/api/rooms/";
        //        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsInVzZXIiOnsiX2lkIjoiNjViNDRmMTZhMDJiOTVmNTA4YzU4ZGZlIiwidXNlcl9uYW1lIjoiTWFyaWEiLCJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInBhc3N3b3JkIjoiJDJhJDEwJFZzQy9RbU15UmdJOGJxdVphMVBGUnVybGQyUGdKRG1qM1VGa2oxNE9kN3BwbjVmUnBhbUJxIiwicm9sZSI6ImFkbWluIiwibmFtZSI6Ik1hcmlhIHByeiIsInBob25lIjo2MTUyMjM1MjgsInJlc2VydmF0aW9ucyI6W119LCJpYXQiOjE3MDc4NDI0MTYsImV4cCI6MTcwNzg3MTIxNn0.VWbC9EmgtjJfCL34fI64Gx0EpXGUKDBytSKxD8EpKfY";

        //        using (HttpClientHandler httpClientHandler = new HttpClientHandler())
        //        {
        //            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

        //            using (HttpClient httpClient = new HttpClient(httpClientHandler))
        //            {

        //                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", token);


        //                HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl);

        //                if (responseMessage.IsSuccessStatusCode)
        //                {
        //                    string json = await responseMessage.Content.ReadAsStringAsync();
        //                }
        //            }
        //        }
        //    }catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error: {ex.Message}");
        //    }
        //}

    }


    
}
