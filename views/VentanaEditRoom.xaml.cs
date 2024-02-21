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
using System.Windows.Shapes;

namespace HotelPereMaria
{
    /// <summary>
    /// Lógica de interacción para VentanaEditRoom.xaml
    /// </summary>
    public partial class VentanaEditRoom : Window
    {
        private viewModels.EditRoomVM _viewModel;
        private int room_number;
        public VentanaEditRoom()
        {
            InitializeComponent();
            DataContext = new EditRoomVM(room_number);
            int selectedRoomNumber = ((EditRoomVM)DataContext).SelectedRoomNumber;
            _viewModel = new viewModels.EditRoomVM(selectedRoomNumber);
            DataContext = _viewModel;
        }

        private void OnSelectImageClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
