using HotelPereMaria.models;
using HotelPereMaria.viewModels;
using HotelPereMaria.VistaUser;
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
    /// Lógica de interacción para VistaEditUser.xaml
    /// </summary>
    public partial class VistaEditUser : Window
    {
        public string Email { get; private set; }
        private VistaEditUserVM vistaEditUserVM;

        public VistaEditUser(string email)
        {
            InitializeComponent();
            Email = email;
            vistaEditUserVM = new VistaEditUserVM();
            DataContext = vistaEditUserVM;
            LoadUser(Email);
        }

        private async void LoadUser(string email)
        {
            await vistaEditUserVM.LoadUser(email);
        }

        private async void ModifyUser(string email, UserModel userModified)
        {
            await vistaEditUserVM.ModifyUser(email, userModified);
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            UserModel userModified = new UserModel(
                txtBoxName.Text, 
                txtBoxUsername.Text,
                txtBoxEmail.Text,
                dpBirthDate.SelectedDate.Value, 
                txtBoxPhone.Text
            );
            ModifyUser(Email, userModified);
        }
    }
}
