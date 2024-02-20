using HotelPereMaria.viewModels;
using HotelPereMaria.VistaUser;
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
    /// Lógica de interacción para VentanaBuscador.xaml
    /// </summary>
    public partial class VentanaBuscador : Window
    {
        private RoomVM _roomVM;
        public VentanaBuscador()
        {
            InitializeComponent();
            _roomVM = new RoomVM();
            DataContext = _roomVM;
            this.LoadRooms();
            using HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        }

        public async Task LoadRooms()
        {
            await _roomVM.LoadRooms();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnReservar1_Click(object sender, RoutedEventArgs e)
        {
            //VentanaReserva vtnReserva = new VentanaReserva();
            //vtnReserva.Show();
        }

        private void btnReservar2_Click(object sender, RoutedEventArgs e)
        {
            //VentanaReserva vtnReserva = new VentanaReserva();
            //vtnReserva.Show();
        }

        private void btnReservar3_Click(object sender, RoutedEventArgs e)
        {
            //VentanaReserva vtnReserva = new VentanaReserva();
            //vtnReserva.Show();
        }

        private void btnReservar4_Click(object sender, RoutedEventArgs e)
        {
            //VentanaReserva vtnReserva = new VentanaReserva();
            //vtnReserva.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            VistaUserView vu = new VistaUserView();
            vu.Show();
        }

        private void btnListUsers_Click(object sender, RoutedEventArgs e)
        {
            VistaDatagridView vdg = new VistaDatagridView();
            vdg.Show();
        }
    }
}
