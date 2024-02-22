using HotelPereMaria.models;
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
    /// Lógica de interacción para VentanaAddEditUser.xaml
    /// </summary>
    public partial class VentanaAddEditUser : Window
    {
        private VistaAddUserVM vistaAddUserVM;
        public VentanaAddEditUser()
        {
            InitializeComponent();
            vistaAddUserVM = new VistaAddUserVM();
        }

        private async void AddUser(UserModel newUser)
        {
            await vistaAddUserVM.AddUser(newUser);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Roles.SelectedItem != null)
            {
                string selectedRole = ((ComboBoxItem)Roles.SelectedItem).Content.ToString();
                string rol = "";

                if (selectedRole == "Usuario")
                {
                    rol = "user";
                }
                else if (selectedRole == "Administrador")
                {
                    rol = "admin";
                }
                UserModel newUser = new UserModel(
                    txtBoxName.Text,
                    txtBoxUsername.Text,
                    txtBoxEmail.Text.ToLower(),
                    dpBirthDate.SelectedDate.Value,
                    txtBoxPhone.Text,
                    rol, 
                    txtBoxPassword.ToString()
                );
                AddUser(newUser);
            }
        }
    }
}
