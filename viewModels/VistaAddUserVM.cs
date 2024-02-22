using HotelPereMaria.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelPereMaria.viewModels
{
    public class VistaAddUserVM : INotifyPropertyChanged
    {
        private UserModel _user;
        public event PropertyChangedEventHandler? PropertyChanged;

        public UserModel User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public async Task AddUser(UserModel newUser)
        {
            try
            {
                string apiUrl = $"https://localhost/api/register";

                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient client = new HttpClient(handler))
                    {
                        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImNoaXRhbkBnbWFpbC5jb20iLCJyb2xlIjoiYWRtaW4iLCJpYXQiOjE3MDgwOTY5NjksImV4cCI6MTczOTY1NDU2OX0.dcO9K6elJIYVWmlwcZ4DvwJWBQu6X7X8sDzS4yAsPLc";
                        client.DefaultRequestHeaders.Add("Authorization", token);

                        string json = JsonConvert.SerializeObject(newUser, Formatting.Indented);
                        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Usuario agregado con éxito: {response.StatusCode}");
                        }
                        else
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            dynamic result = JObject.Parse(responseBody);
                            MessageBox.Show($"Error al agregar el usuario: {result}");
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
