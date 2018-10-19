using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public DateTime DateBook { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public float TotalDays
        {
            get
            {
                if (CheckIn == null)
                {
                    return 0;
                }
                else
                {
                    if (CheckOut == null)
                    {
                        return 0;
                    }
                    else
                    {
                        if (CheckOut >= CheckIn)
                        {
                            return (CheckOut - CheckIn).Value.Days;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }
        public int NAdults { get; set; }
        public int NChilds { get; set; }
        public int TotalPeople
        {
            get
            {
                return NAdults + NChilds;
            }
        }
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int GetRoomNumber
        {
            get
            {
                if(RoomID > 0)
                {
                    CDBContext db = new CDBContext();
                    return db.Rooms.FirstOrDefault(r => r.RoomID == RoomID).RoomNumber;
                }
                return RoomNumber;
            }
            set
            {

            }
        }
        public float RoomPrice { get; set; }
        public float GetRoomPrice
        {
            get
            {
                if (RoomID > 0)
                {
                    CDBContext db = new CDBContext();
                    return db.Rooms.FirstOrDefault(r => r.RoomID == RoomID).RoomPrice;
                }
                return RoomPrice;
            }

        }

        public float TotalPrices
        {
            get
            {
                return TotalDays * GetRoomPrice;
            }
        }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string GetCustomerName
        {
            get
            {
                if (CustomerID > 0)
                {
                    CDBContext db = new CDBContext();
                    return db.Customers.FirstOrDefault(r => r.CustomerID == CustomerID).CustomerName;
                }
                return CustomerName;
            }
            set
            {

            }
        }
        public string CustomerNRIC { get; set; }
        public string GetCustomerNRIC
        {
            get
            {
                if (CustomerID > 0)
                {
                    CDBContext db = new CDBContext();
                    return db.Customers.FirstOrDefault(r => r.CustomerID == CustomerID).NRIC;
                }
                return CustomerNRIC;
            }
            set
            {

            }
        }
        public DateTime CustomerDOB { get; set; }
        public DateTime GetCustomerDOB
        {
            get
            {
                if (CustomerID > 0)
                {
                    CDBContext db = new CDBContext();
                    return db.Customers.FirstOrDefault(r => r.CustomerID == CustomerID).DOB;
                }
                return CustomerDOB;
            }
            set
            {

            }
        }
    }
}
