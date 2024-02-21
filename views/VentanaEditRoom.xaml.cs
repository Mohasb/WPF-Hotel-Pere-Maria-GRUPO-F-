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
        private EditRoomVM _editRoomVM;
        private int room_number;
        public VentanaEditRoom()
        {
            InitializeComponent();
            _editRoomVM = new EditRoomVM(room_number);
            DataContext = _editRoomVM;
            this.LoadRoomsByNumber();

        }
        public async Task LoadRoomsByNumber()
        {
            await _editRoomVM.LoadRoomsByNumber(room_number);
        }

        private void OnSelectImageClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
