using Flixster.Dtos;
using Flixster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flixster.Controllers.API
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            List<Rental> rentals = new List<Rental>();

            foreach(int movieId in rentalDto.MovieIds)
            {
                var newRental = new Rental
                {
                    //CustomerId = rentalDto.CustomerId,
                    //MovieId = movieId
                };
                _context.Rentals.Add(newRental);
                rentals.Add(newRental);
            }

            _context.SaveChanges();

            return Ok(rentals);
        }
    }
}
