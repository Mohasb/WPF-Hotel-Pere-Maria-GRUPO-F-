

using HotelPereMaria.models;
using System.Windows.Input;
using System;
using System.ComponentModel;

namespace HotelPereMaria.viewModels
{
    public class ReservaVM
    {
        private UserModel _currentUser;
        private DateTime _fechaEntrada;
        private DateTime _fechaSalida;
        private int _numeroHuespedes;
        private string _tipoHabitacion;



        public ReservaVM(UserModel currentUser)
        {
            _currentUser = currentUser;
        }
        public UserModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
            }
        }

        
    }
}
