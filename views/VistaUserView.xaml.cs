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
        private VistaUserVM viewModel;
        public VistaUserView()
        {
            InitializeComponent();
            viewModel = new();
            DataContext = viewModel;
            LoadReservations();
        }

        private async void LoadReservations()
        {
           await viewModel.LoadReservations("correo1@example.com");
        }
        
    }
}
