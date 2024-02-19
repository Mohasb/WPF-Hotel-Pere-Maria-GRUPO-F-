using HotelPereMaria.viewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelPereMaria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        private LoginVM viewModel;

        public MainWindow()
        {
            InitializeComponent();
            //Email = email;
            viewModel = new();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //VentanaBuscador vtnBuscador = new VentanaBuscador();
            //vtnBuscador.Show();
            //this.Close();
            this.Login();
        }

        public async Task Login()
        {
            await viewModel.Login(txtEmail.Text, txtPassword.Password);
        }
    }
}
