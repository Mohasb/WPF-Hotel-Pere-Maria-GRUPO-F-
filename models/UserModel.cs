using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPereMaria.models
{

    public class UserModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public string role { get; set; }
        public int phone { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
