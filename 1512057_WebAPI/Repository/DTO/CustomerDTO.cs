using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string NRIC { get; set; }
        public DateTime DOB { get; set; }
    }
}
