using Domain;
using Repository;
using Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class BookingController : ApiController
    {
        Repo rp = new Repo();
        //
        #region Test API
        [HttpGet]
        [Route("api/Booking/GetListBooking")]
        public IEnumerable<BookingDTO> GetListBooking()
        {
            IList<BookingDTO> lbr = new List<BookingDTO>();
            lbr = rp.GetListBooking();
            return lbr;
        }

        [HttpGet]
        [Route("api/Booking/GetListCustomer")]
        public IEnumerable<CustomerDTO> GetListCustomer()
        {
            IList<CustomerDTO> lcus = new List<CustomerDTO>();
            lcus = rp.GetListCustomer();
            return lcus;
        }
        #endregion
        //
        //API #1
        //
        #region API #1
        [HttpGet]
        [Route("api/Booking/GetBookingByNRIC/cnmd/{cmnd}")]
        public IEnumerable<BookingDTO> GetBookingByNRIC(string cmnd)
        {
            IList<BookingDTO> lbr = new List<BookingDTO>();
            lbr = rp.GetCustomerByNRIC(cmnd);
            return lbr;
        }
        #endregion

        ///
        //
        //API #2
        #region API #2
        [HttpPost]
        ////[Route("api/Booking/AddNewBooking")]
        public IHttpActionResult AddNewBooking(BookingDTO booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Booking br = rp.AddNewBooking(booking);
            //return CreatedAtRoute("DefaultApi", new { id =  br.BookingID}, br);
            return CreatedAtRoute("Booking", new { id = br.BookingID }, br);
        }

        #endregion
    }
}
