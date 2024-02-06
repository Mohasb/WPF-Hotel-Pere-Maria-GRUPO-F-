
using HotelPereMaria.models;
using HotelPereMaria.viewModels;
using System.Windows;

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
    }
}
