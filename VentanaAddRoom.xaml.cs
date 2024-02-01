using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
