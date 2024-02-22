using HotelPereMaria.viewModels;
using HotelPereMaria.VistaUser;
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
        private VistaDatagridVM datagridViewModel;

        public VistaDatagridView()
        {
            InitializeComponent();
            datagridViewModel = new();
            DataContext = datagridViewModel;
            LoadUsers();
        }

        private async void LoadUsers()
        {
            await datagridViewModel.LoadUsers();
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            dgUsers.Visibility = toggleBtn.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            lblIconBtn.Content = "ListView";
            lvUsers.Visibility = toggleBtn.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            dgUsers.Visibility = toggleBtn.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            lblIconBtn.Content = "DataGrid";
            lvUsers.Visibility = toggleBtn.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
