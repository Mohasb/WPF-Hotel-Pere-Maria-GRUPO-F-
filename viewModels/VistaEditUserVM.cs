using HotelPereMaria.models;
using HotelPereMaria.models.HotelPereMaria.models;
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

namespace HotelPereMaria.viewModels
{
    public class VistaEditUserVM : INotifyPropertyChanged
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

        public async Task LoadUser(string userEmail)
        {
            try
            {
                string apiUrl = $"https://localhost/api/users/{userEmail}";

                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient client = new HttpClient(handler))
                    {
                        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImNoaXRhbkBnbWFpbC5jb20iLCJyb2xlIjoiYWRtaW4iLCJpYXQiOjE3MDgwOTY5NjksImV4cCI6MTczOTY1NDU2OX0.dcO9K6elJIYVWmlwcZ4DvwJWBQu6X7X8sDzS4yAsPLc";
                        client.DefaultRequestHeaders.Add("Authorization", token);

                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string json = await response.Content.ReadAsStringAsync();
                            var user = JsonConvert.DeserializeObject<UserModel>(json);

                            User = user;

                            MessageBox.Show($"Usuario cargado con exito: {response.StatusCode}");
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

        public async Task ModifyUser(string userEmail, UserModel modifiedUser)
        {
            try
            {
                string apiUrl = $"https://localhost/api/users/{userEmail}";

                using (HttpClientHandler handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                    using (HttpClient client = new HttpClient(handler))
                    {
                        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImNoaXRhbkBnbWFpbC5jb20iLCJyb2xlIjoiYWRtaW4iLCJpYXQiOjE3MDgwOTY5NjksImV4cCI6MTczOTY1NDU2OX0.dcO9K6elJIYVWmlwcZ4DvwJWBQu6X7X8sDzS4yAsPLc";
                        client.DefaultRequestHeaders.Add("Authorization", token);

                        string json = JsonConvert.SerializeObject(modifiedUser);

                        var request = new HttpRequestMessage(new HttpMethod("PATCH"), apiUrl)
                        {
                            Content = new StringContent(json, Encoding.UTF8, "application/json")
                        };

                        HttpResponseMessage response = await client.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Usuario modificado con éxito: {response.StatusCode}");
                        }
                        else
                        {
                            MessageBox.Show($"Error al modificar el usuario: {response.StatusCode}");
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
