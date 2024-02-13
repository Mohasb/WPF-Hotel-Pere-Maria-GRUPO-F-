using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelPereMaria
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
            lvUsers.ItemsSource = LoadCollectionData();

        }
        private ObservableCollection<User> LoadCollectionData()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();

            users.Add(new User()
            {
                IsSelected = false,
                ID = 201,
                Foto = "",
                Nombre = "Jiandan",
                Rol = "Administrador",
                IsVIP = true
            });

            users.Add(new User()
            {
                IsSelected = false,
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
            public bool IsSelected { get; set; }
            public int ID { get; set; }
            public string Foto { get; set; }
            public string Nombre { get; set; }
            public string Rol { get; set; }
            public bool IsVIP { get; set; }
        }

        private void chkSelectAll_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool AllChecked = (chkSelectAll.IsChecked == true);
            foreach (User user in dgUsers.Items)
            {
                user.IsSelected = AllChecked;
                MessageBox.Show(user.IsSelected.ToString());
            }
        }

        private void colchkSelect1_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool allSelected = dgUsers.Items.Cast<User>().All(user => user.IsSelected);
            MessageBox.Show(allSelected.ToString());
            bool anySelected = dgUsers.Items.Cast<User>().Any(user => user.IsSelected);
            MessageBox.Show(anySelected.ToString());

            if (allSelected)
            {
                chkSelectAll.IsChecked = true;
            }
            else if (anySelected)
            {
                chkSelectAll.IsChecked = false;
            }
            else
            {
                chkSelectAll.IsChecked = false;
            }
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

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            dgUsers.Visibility = toggleBtn.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            lvUsers.Visibility = toggleBtn.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            dgUsers.Visibility = toggleBtn.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            lvUsers.Visibility = toggleBtn.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
