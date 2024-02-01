using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HotelPereMaria.vistaDatagrid
{
    /// <summary>
    /// Lógica de interacción para VistaDatagridView.xaml
    /// </summary>
    public partial class VistaDatagridView : Window
    {
        public VistaDatagridView()
        {
            InitializeComponent();
            dgUsers.ItemsSource = LoadCollectionData();
        }
        private ObservableCollection<User> LoadCollectionData()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();

            users.Add(new User()
            {
                isSelected = false,
                ID = 201,
                Foto = "",
                Nombre = "Jiandan",
                Rol = "Administrador",
                IsVIP = true
            });

            users.Add(new User()
            {
                isSelected = false,
                ID = 200,
                Foto = "",
                Nombre = "Chitan",
                Rol = "Administrador",
                IsVIP = true
            });

            return users;
        }

        public class User
        {
            public bool isSelected { get; set; }
            public int ID { get; set; }
            public string Foto { get; set; }
            public string Nombre { get; set; }
            public string Rol { get; set; }
            public bool IsVIP { get; set; }
        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            bool AllChecked = (chkSelectAll.IsChecked == true);
            colchkSelect1.IsChecked = AllChecked;
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dgUsers.Items.Cast<User>().All(user => user.isSelected))
            {
                foreach (User user in dgUsers.Items)
                {
                    user.isSelected = false;
                }
            }
            else
            {
                foreach (User user in dgUsers.Items)
                {
                    user.isSelected = true;
                }
            }
        }

        private void colchkSelect1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void colchkSelect1_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
