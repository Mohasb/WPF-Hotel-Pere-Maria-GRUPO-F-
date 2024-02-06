
using HotelPereMaria.viewModels;
using System.Windows;

namespace HotelPereMaria
{
    /// <summary>
    /// Lógica de interacción para VentanaReserva.xaml
    /// </summary>
    public partial class VentanaReserva : Window
    {

        ReservaVM ViewModel { get; set; }
        User CurrentUser { get; set; }

        public VentanaReserva(User currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            ViewModel = new ReservaVM(currentUser);
            DataContext = ViewModel;
        }
    }
}
