
using HotelPereMaria.models;
using HotelPereMaria.viewModels;
using System.Windows;


namespace HotelPereMaria.VistaUser
{
    /// <summary>
    /// Lógica de interacción para VistaUserView.xaml
    /// </summary>
    public partial class VistaUserView : Window
    {
        public string Email { get; private set; }
        private VistaUserVM viewModel;

        public VistaUserView(string email)
        {
            InitializeComponent();
            Email = email;
            viewModel = new();
            DataContext = viewModel;
            LoadReservations(Email);
        }

        private async void LoadReservations(string email)
        {
           await viewModel.LoadReservations(Email);
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            dataGrid.Visibility = toggleButton.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            listView.Visibility = toggleButton.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            dataGrid.Visibility = toggleButton.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            listView.Visibility = toggleButton.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }

        private void BtnReserva_Click(object sender, RoutedEventArgs e)
        {
            UserModel currentUser = viewModel.CurrentUser;
            VentanaReserva vr = new VentanaReserva(currentUser);
            vr.Show();
        }
    }
}
