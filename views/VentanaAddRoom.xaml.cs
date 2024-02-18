using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelPereMaria
{
    /// <summary>
    /// Lógica de interacción para VentanaAddRoom.xaml
    /// </summary>
    public partial class VentanaAddRoom : Window
    {
        public VentanaAddRoom()
        {
            InitializeComponent();
        }

        private void OnSelectImageClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                BitmapImage bitmap = new BitmapImage(new Uri(selectedImagePath));
                //selectedImage.Source = bitmap; esto es por si quiero mostrar la imagen en algún sitio
            }
        }

        private async void OnEnviarClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var roomDetails = new
                {
                    room_number = txtRoomNumber.Text,
                    type = txtRoomType.Text,
                };

                string apiUrl = "https://localhost/api/rooms/";

                using (var httpClient = new HttpClient())
                {
                    var jsonContent = JsonConvert.SerializeObject(roomDetails);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Habitación añadida exitosamente.");
                        txtRoomNumber.Text = string.Empty;
                        txtRoomType.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show($"Error al añadir la habitación. Código de estado: {response.StatusCode}");
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
