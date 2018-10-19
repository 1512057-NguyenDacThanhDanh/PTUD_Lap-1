using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository.DTO;

namespace Repository
{
    public class Repo
    {
        CDBContext db = new CDBContext();
        public IList<BookingDTO> GetListBooking()
        {
            IList<BookingDTO> lbr = new List<BookingDTO>();
            var br = db.Bookings.Select(b => new BookingDTO
            {
                BookingID = b.BookingID,
                CheckIn = b.CheckIn,
                CheckOut = b.CheckOut,
                DateBook = b.DateBook,
                NAdults = b.NAdults,
                NChilds = b.NChilds,
                RoomID = b.RoomID,
                CustomerID = b.CustomerID
            }).ToList();
            if (br.Count() <= 0)
            {
                return null;
            }
            foreach (var item in br)
            {
                lbr.Add(new BookingDTO
                {
                    BookingID = Convert.ToInt32(item.BookingID),
                    CheckIn = item.CheckIn,
                    CheckOut = item.CheckOut,
                    CustomerID = Convert.ToInt32(item.CustomerID),
                    DateBook = item.DateBook,
                    NAdults = Convert.ToInt32(item.NAdults),
                    NChilds = Convert.ToInt32(item.NChilds),
                    RoomID = Convert.ToInt32(item.RoomID),
                });
            }
            return lbr;
        }

        //
        public IList<CustomerDTO> GetListCustomer()
        {
            IList<CustomerDTO> lbr = new List<CustomerDTO>();
            var br = db.Customers.Select(b => new CustomerDTO
            {
                CustomerID = b.CustomerID,
                CustomerName = b.CustomerName,
                DOB = b.DOB,
                NRIC = b.NRIC,
            }).ToList();
            if (br.Count() <= 0)
            {
                return null;
            }
            foreach (var item in br)
            {
                lbr.Add(new CustomerDTO
                {
                    CustomerID = Convert.ToInt32(item.CustomerID),
                    CustomerName = item.CustomerName,
                    DOB = item.DOB,
                    NRIC = item.NRIC,
                });
            }
            return lbr;
        }
        ///
        ////
        /////
        //

        public IList<BookingDTO> GetCustomerByNRIC(string cmnd)
        {
            IList<BookingDTO> lbr = new List<BookingDTO>();
            var br = db.Bookings.Join(
                db.Customers,
                b => b.CustomerID,
                c => c.CustomerID,
                (b, c) => new { b, c }).Join(
                db.Rooms,
                bb => bb.b.RoomID,
                r => r.RoomID,
                (bb, r) => new
                {
                    BookingID = bb.b.BookingID,
                    DateBook = bb.b.DateBook,
                    CheckIn = bb.b.CheckIn,
                    CheckOut = bb.b.CheckOut,
                    CustomerID = bb.b.CustomerID,
                    CustomerName = bb.c.CustomerName,
                    CustomerNRIC = bb.c.NRIC,
                    CustomerDOB = bb.c.DOB,
                    NAdults = bb.b.NAdults,
                    NChilds = bb.b.NChilds,
                    RoomID = bb.b.RoomID,
                    RoomNumber = r.RoomNumber,
                    RoomPrice = r.RoomPrice,
                }).Where(brt => brt.CustomerNRIC == cmnd).Select(x => new BookingDTO
                {
                    BookingID = x.BookingID,
                    CustomerID = x.CustomerID,
                    CustomerName = x.CustomerName,
                    CustomerNRIC = x.CustomerNRIC,
                    CustomerDOB = x.CustomerDOB,
                    CheckIn = x.CheckIn,
                    CheckOut = x.CheckOut,
                    DateBook = x.DateBook,
                    NAdults = x.NAdults,
                    NChilds = x.NChilds,
                    RoomID = x.RoomID,
                    RoomNumber = x.RoomNumber,
                    RoomPrice = x.RoomPrice,
                }).ToList();
            if (br.Count() <= 0)
            {
                return null;
            }
            foreach (var item in br)
            {
                lbr.Add(new BookingDTO
                {
                    BookingID = Convert.ToInt32(item.BookingID),
                    CheckIn = item.CheckIn,
                    CheckOut = item.CheckOut,
                    CustomerID = Convert.ToInt32(item.CustomerID),
                    DateBook = item.DateBook,
                    NAdults = Convert.ToInt32(item.NAdults),
                    NChilds = Convert.ToInt32(item.NChilds),
                    RoomPrice = item.RoomPrice,
                    RoomID = Convert.ToInt32(item.RoomID),
                    CustomerDOB = item.CustomerDOB,
                    CustomerName = item.CustomerName,
                    CustomerNRIC = item.CustomerNRIC,
                    RoomNumber = item.RoomNumber,
                });  
            }
            return lbr;
        }

        /////
        ////
        ///
         //
        public Booking AddNewBooking(BookingDTO booking)
        {
            Customer cus = new Customer()
            {
                CustomerName = booking.CustomerName,
                DOB = booking.CustomerDOB,
                NRIC = booking.CustomerNRIC,
            };
            db.Customers.Add(cus);
            db.SaveChanges();
            int cusid = db.Customers.FirstOrDefault(c => c.NRIC == cus.NRIC).CustomerID;
            Booking br = new Booking()
            {
                DateBook = DateTime.Now,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                CustomerID = cusid,
                NAdults = booking.NAdults,
                NChilds = booking.NChilds,
                RoomID = booking.RoomID,
                FK_Booking_Customer = db.Customers.FirstOrDefault(c => c.NRIC == cus.NRIC),
                FK_Booking_Room = db.Rooms.FirstOrDefault(r => r.RoomID == booking.RoomID),
            };
            db.Bookings.Add(br);
            db.SaveChanges();
            return br;
        }
    }
}
