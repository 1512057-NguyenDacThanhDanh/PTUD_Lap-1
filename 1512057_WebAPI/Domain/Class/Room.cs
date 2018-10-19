using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public float RoomPrice { get; set; }
        //Quan he 1..*
        public ICollection<Booking> Room_Bookings { get; set; }
    }
}