using HotelPereMaria.models.HotelPereMaria.models;
using HotelPereMaria.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using HotelPereMaria.VistaUser;

namespace HotelPereMaria.viewModels
{
    public class VistaDatagridVM : INotifyPropertyChanged
    {
        private ObservableCollection<UserModel> _users;
        public event PropertyChangedEventHandler? PropertyChanged;
        private RelayCommand _infCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _editCommand;

        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        public RelayCommand InformationCommand
        {
            get
            {
                if (_infCommand == null)
                {
                    _infCommand = new RelayCommand(param => GetInfoUser((UserModel)param), param => true);
                }
                return _infCommand;
            }
        }

        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(param => DeleteUserAndApiAsync((UserModel)param), param => true);
                }
                return _deleteCommand;
            }
        }

        public RelayCommand EditCommad
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand(param => ModifyUser((UserModel)param), param => true);
                }
                return _editCommand;
            }
        }

        private void GetInfoUser(UserModel user)
        {
            VistaUserView vistaUserView = new VistaUserView(user.email);
            vistaUserView.Show();
            MessageBox.Show("EMAIL: "+user.email);
        }

        private void DeleteUser(UserModel user)
        {
            if (user != null)
            {
                int index = Users.IndexOf(user);
                if (index != -1)
                {
                    Users.RemoveAt(index);
                }
            }
        }

        private void ModifyUser(UserModel user)
        {
            VistaEditUser vistaEditUser = new VistaEditUser(user.email);
            vistaEditUser.Show();
            MessageBox.Show("EMAIL: " + user.email);
        }

        public async Task LoadUsers()
        {
            try
            {
                string apiUrl = $"https://localhost/api/users";

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
                            var users = JsonConvert.DeserializeObject<ObservableCollection<UserModel>>(json);

                            Users = users;

                            MessageBox.Show($"Usuarios cargado con exito: {response.StatusCode}");
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

        private async Task DeleteUserAndApiAsync(UserModel user)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este?", "Confirmación", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                DeleteUser(user);

                if (user != null)
                {
                    string userEmail = user.email;
                    await DeleteUserApiAsync(userEmail);
                }
            }
        }

        private async Task DeleteUserApiAsync(string userEmail)
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
                        HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show($"Error: {response.StatusCode}");
                        }
                        else
                        {
                            MessageBox.Show($"Exito al borrar usuario");
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
