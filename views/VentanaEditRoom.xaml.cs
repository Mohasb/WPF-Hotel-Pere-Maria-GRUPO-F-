using HotelPereMaria.viewModels;
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
    /// Lógica de interacción para VentanaEditRoom.xaml
    /// </summary>
    public partial class VentanaEditRoom : Window
    {
        //private EditRoomVM _editRoomVM;
        private int room_number;
        private RoomDetailsVM _roomDetailsVM;
        public VentanaEditRoom()
        {
            InitializeComponent();
            //_editRoomVM = new EditRoomVM(room_number);
            _roomDetailsVM = new RoomDetailsVM();
            DataContext = _roomDetailsVM;
            //this.GetRoomDetails();
            using HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            GetRooms();

        }
        private async void GetRooms()
        {
            await _roomDetailsVM.GetRooms();
        }
        private void OnSelectImageClick(object sender, RoutedEventArgs e)
        {

        }

    }
}
