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

        public UserModel() { }
        public UserModel(string name, string userName, string email, DateTime birthDate, string phone)
        {
            name = name;
            user_name = userName;
            email = email;
            birth_date = birthDate;
            phone = phone;
        }
    }
}
