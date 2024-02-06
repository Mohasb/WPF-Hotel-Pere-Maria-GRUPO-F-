
using HotelPereMaria.models;
using HotelPereMaria.viewModels;
using System.Globalization;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HotelPereMaria
{
    /// <summary>
    /// Lógica de interacción para VentanaReserva.xaml
    /// </summary>
    public partial class VentanaReserva : Window
    {

        public VentanaReserva(UserModel currentUser)
        {
            InitializeComponent();
            DataContext = new ReservaVM(currentUser);
        }


        private string ConvertTipoHabitacionToImage(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return "../Images/rooms/estandar.jpg";
                case 1:
                    return "../Images/rooms/individual.jpg";
                case 2:
                    return "../Images/rooms/familiar.jpg";
                case 3:
                    return "../Images/rooms/deluxe.jpg";
                case 4:
                    return "../Images/rooms/suite.jpg";
                default:
                    return "../Images/rooms/estandar.jpg";
            }
        }

        private void comboboxTipoHab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedRoom = comboboxTipoHab.SelectedIndex;
            if (selectedRoom >= 0)
            {
                string imagePath = ConvertTipoHabitacionToImage(selectedRoom);

                // Actualiza la imagen de la habitación
                imageRoom.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
