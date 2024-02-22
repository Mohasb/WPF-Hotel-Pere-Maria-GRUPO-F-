using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelPereMaria.models
{

    public class UserModel
    {
        public string name { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        public DateTime birth_date { get; set; }
        public string role { get; set; }
        public string phone { get; set; }
        public string password { get; set; }

        public UserModel() { }
        public UserModel(string Name, string UserName, string Email, DateTime birthDate, string Phone)
        {
            name = Name;
            user_name = UserName;
            email = Email;
            birth_date = birthDate;
            phone = Phone;
        }

        public UserModel(string Name, string UserName, string Email, DateTime birthDate, string Phone, string Role, string Password)
        {
            name = Name;
            user_name = UserName;
            email = Email;
            birth_date = birthDate;
            phone = Phone;
            role = Role;
            password = Password;
        }
    }
}
