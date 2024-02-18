using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPereMaria.models
{
    using Newtonsoft.Json;

    namespace HotelPereMaria.models
    {
        public class PostExtra
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("value")]
            public bool Value { get; set; }
        }

        public class User
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("user_name")]
            public string UserName { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("phone")]
            public int Phone { get; set; }
        }

        public class PostReservation
        {
            [JsonProperty("extras")]
            public List<PostExtra> Extras { get; set; }

            [JsonProperty("user")]
            public User User { get; set; }

            [JsonProperty("check_in_date")]
            public DateTime CheckInDate { get; set; }

            [JsonProperty("check_out_date")]
            public DateTime CheckOutDate { get; set; }

            [JsonProperty("cancelationDate")]
            public DateTime CancelationDate { get; set; }

            [JsonProperty("roomType")]
            public string RoomType { get; set; }

            [JsonProperty("ocupation")]
            public int Ocupation { get; set; }
        }
    }

}
