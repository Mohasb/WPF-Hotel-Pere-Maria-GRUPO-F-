using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HotelPereMaria.VistaUser
{
    /// <summary>
    /// Lógica de interacción para VistaUserView.xaml
    /// </summary>
    public partial class VistaUserView : Window
    {
        public string Email { get; private set; }
        private VistaUserVM viewModel;

        public VistaUserView(/*string email*/)
        {
            InitializeComponent();
            //Email = email;
            viewModel = new();
            DataContext = viewModel;
            LoadReservations(/*Email*/);
        }

        private async void LoadReservations(/*string email*/)
        {
           await viewModel.LoadReservations(/*Email*/"correo1@example.com");
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            toggleButton.Content = "Cambiar vista a ListView";
            dataGrid.Visibility = toggleButton.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            listView.Visibility = toggleButton.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            toggleButton.Content = "Cambiar vista a DataGrid";
            dataGrid.Visibility = toggleButton.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            listView.Visibility = toggleButton.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }

        private void BtnReserva_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = viewModel.CurrentUser;

            VentanaReserva vr = new VentanaReserva(currentUser);
            vr.Show();
        }
    }
}
