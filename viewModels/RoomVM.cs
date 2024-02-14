using HotelPereMaria.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelPereMaria.viewModels
{
    public class RoomVM
    {
        //private UserModel _user;
        //private int _room_number;
        //private string _type;
        //private string _description;
        //private double _price_per_night;
        //private int _rate;
        //private int _max_occupancy;
        //private Boolean _isAvailable;


        public async Task LoadRooms(string userEmail = "correo1@example.com")
        {
            try
            {
                string apiUrl = $"https://localhost/api/rooms/";
                string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInJvbGUiOiJhZG1pbiIsInVzZXIiOnsiX2lkIjoiNjViNDRmMTZhMDJiOTVmNTA4YzU4ZGZlIiwidXNlcl9uYW1lIjoiTWFyaWEiLCJlbWFpbCI6Im1hcmlhQGdtYWlsLmNvbSIsInBhc3N3b3JkIjoiJDJhJDEwJFZzQy9RbU15UmdJOGJxdVphMVBGUnVybGQyUGdKRG1qM1VGa2oxNE9kN3BwbjVmUnBhbUJxIiwicm9sZSI6ImFkbWluIiwibmFtZSI6Ik1hcmlhIHByeiIsInBob25lIjo2MTUyMjM1MjgsInJlc2VydmF0aW9ucyI6W119LCJpYXQiOjE3MDc4NDI0MTYsImV4cCI6MTcwNzg3MTIxNn0.VWbC9EmgtjJfCL34fI64Gx0EpXGUKDBytSKxD8EpKfY";

                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient httpClient = new HttpClient(httpClientHandler))
                    {

                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", token);


                        HttpResponseMessage responseMessage = await httpClient.GetAsync(apiUrl);

                        if (responseMessage.IsSuccessStatusCode)
                        {
                            string json = await responseMessage.Content.ReadAsStringAsync();
                        }
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }


    
}
