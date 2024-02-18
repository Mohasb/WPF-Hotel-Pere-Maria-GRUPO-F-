
using HotelPereMaria.models;
using HotelPereMaria.viewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HotelPereMaria
{
    /// <summary>
    /// Lógica de interacción para VentanaReserva.xaml
    /// </summary>
    public partial class VentanaReserva : Window
    {
        private ReservaVM _reservaVM;
        public VentanaReserva(UserModel currentUser)
        {
            InitializeComponent();
            _reservaVM = new ReservaVM(currentUser);
            DataContext = _reservaVM;
            comboboxTipoHab.Loaded += (sender, e) =>
            {
                comboboxTipoHab.SelectedIndex = 0;
            };
            checkIn.DisplayDateStart = DateTime.Today.AddDays(1);
            checkOut.DisplayDateStart = DateTime.Today.AddDays(2);
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
                if (comboboxTipoHab.SelectedItem is ComboBoxItem selectedItem)
                {
                    _reservaVM.SelectedRoomType = selectedItem.Content?.ToString();
                }

                // Actualiza la imagen de la habitación
                imageRoom.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
            }
            

            this.UpdateHuespedes();
        }

        private void UpdateHuespedes()
        {
            huespedes.Items.Clear();

            // Añadir elementos según la selección de tipo de habitación
            switch (comboboxTipoHab.SelectedIndex)
            {
                case 0: // Habitación Estandar
                    huespedes.Items.Add(1);
                    huespedes.Items.Add(2);
                    break;
                case 2: // Habitación Familiar
                    for (int i = 1; i <= 5; i++)
                    {
                        huespedes.Items.Add(i);
                    }
                    break;
                case 1: // Habitación Individual
                    huespedes.Items.Add(1);
                    break;
                case 3: // Habitación Deluxe
                case 4: // Habitación Suite
                    huespedes.Items.Add(1);
                    huespedes.Items.Add(2);
                    break;
            }

            huespedes.SelectedIndex = 0;
        }

        private async void BtnReserva_Click(object sender, RoutedEventArgs e)
        {
            if (this.ValidateValues())
            {
               await _reservaVM.makeReservation(
                    _reservaVM.FechaEntrada,
                    _reservaVM.FechaSalida,
                    _reservaVM.NumeroHuespedes,
                    _reservaVM.TipoHabitacion,
                    _reservaVM.WifiSelected,
                    _reservaVM.AllInclusiveSelected,
                    _reservaVM.GymSelected,
                    _reservaVM.SpaSelected,
                    _reservaVM.ParkingSelected
                    );
            }


        }

        private bool ValidateValues()
        {
            if (string.IsNullOrEmpty(checkIn.SelectedDate.ToString()))
            {
                MessageBox.Show("Por favor, selecciona la fecha de entrada.", "Campo requerido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(checkOut.SelectedDate.ToString()))
            {
                MessageBox.Show("Por favor, selecciona la fecha de salida.", "Campo requerido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (checkOut.SelectedDate <= checkIn.SelectedDate)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la fecha de entrada.", "Fecha inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (huespedes.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona el número de huéspedes.", "Campo requerido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (comboboxTipoHab.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona el tipo de habitación.", "Campo requerido", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
