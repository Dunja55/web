using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public IList<RoomReservation> RoomReservations { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}