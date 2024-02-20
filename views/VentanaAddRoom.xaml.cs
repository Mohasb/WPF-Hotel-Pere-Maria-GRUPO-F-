using HotelPereMaria.viewModels;
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
        private AddRoomVM _addRoom;
        public VentanaAddRoom()
        {
            InitializeComponent();
            _addRoom = new AddRoomVM();
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
            var roomDetails = new
            {
                room_number = txtRoomNumber.Text,
                type = txtRoomType.Text,
                maxOccupancy = txtMaxOccupancy.Text,
                description = txtDescription.Text,
                images = "",
                rate = txtRate.Text,
            };

            await _addRoom.AddRoom(roomDetails);
        }
    }
}
