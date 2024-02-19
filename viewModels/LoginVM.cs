using HotelPereMaria.models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelPereMaria.viewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public async Task Login(string email, string password)
        {
            string apiUrl = "https://localhost/api/login";

            try
            {
                using HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))
                {

                    string json = "{\"email\":\"" + email + "\"," +
                                  "\"password\":\"" + password + "\"}";

                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    string responseBody = await response.Content.ReadAsStringAsync();
                    dynamic result = JObject.Parse(responseBody);
                    string jsonArray = result.data.token;

                    string token = jsonArray;

                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["Token"].Value = token;
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario logueado con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                        VentanaBuscador ventanaBuscador = new VentanaBuscador();
                        ventanaBuscador.Show();

                        // Cerrar la ventana de inicio de sesión (MainWindow)
                        Application.Current.MainWindow.Close();
                        //return true;
                    }
                    else
                    {
                        MessageBox.Show($"Error al realizar la reserva. Código de estado: {response.StatusCode}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        //return false;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de solicitud HTTP: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                //return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                //return false;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
