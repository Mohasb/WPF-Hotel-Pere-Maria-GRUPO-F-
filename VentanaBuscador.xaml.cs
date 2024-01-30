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
    /// Lógica de interacción para VentanaBuscador.xaml
    /// </summary>
    public partial class VentanaBuscador : Window
    {
        public VentanaBuscador()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnReservar1_Click(object sender, RoutedEventArgs e)
        {
            VentanaReserva vtnReserva = new VentanaReserva();
            vtnReserva.Show();
        }

        private void btnReservar2_Click(object sender, RoutedEventArgs e)
        {
            VentanaReserva vtnReserva = new VentanaReserva();
            vtnReserva.Show();
        }

        private void btnReservar3_Click(object sender, RoutedEventArgs e)
        {
            VentanaReserva vtnReserva = new VentanaReserva();
            vtnReserva.Show();
        }

        private void btnReservar4_Click(object sender, RoutedEventArgs e)
        {
            VentanaReserva vtnReserva = new VentanaReserva();
            vtnReserva.Show();
        }
    }
}
