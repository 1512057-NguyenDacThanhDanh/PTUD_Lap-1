using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        [Required]
        public DateTime DateBook { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        [Required]
        public int NAdults { get; set; }
        [Required]
        public int NChilds { get; set; }
        /// <summary>
        /// FK_Booking_Room 
        /// </summary>
        [Required]
        public int RoomID { get; set; }
        [ForeignKey("RoomID")]
        public Room FK_Booking_Room { get; set; }

        /// <summary>
        /// FK_Booking_Customer
        /// </summary>
        [Required]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer FK_Booking_Customer { get; set; }
    }
}