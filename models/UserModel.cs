using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
