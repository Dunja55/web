using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public int RoomNumber { get; set; }
        [Required]
        public int BedCount { get; set; }
        public string Description { get; set; }
        [Required]
        public int PricePerNight { get; set; }

        [ForeignKey("Accommodation")]
        public int AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }

        public IList<RoomReservation> RoomReservations { get; set; }
    }
}