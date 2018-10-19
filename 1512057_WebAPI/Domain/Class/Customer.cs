using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string NRIC { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        //Quan he 1..*
        public ICollection<Booking> Customer_Bookings { get; set; }
    }
}