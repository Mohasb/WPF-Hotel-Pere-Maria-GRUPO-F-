using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPereMaria.models
{
    public class PostExtra
    {
        public string Name { get; set; }
        public bool Value { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public int Phone { get; set; }
    }

    public class PostReservation
    {
        public List<PostExtra> Extras { get; set; }
        public User User { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CancelationDate { get; set; }
        public string roomType { get; set; }
        public int numeroHuespedes {  get; set; }
    }
}
