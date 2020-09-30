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
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("No MovieIds have been given.");

            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (Movie movie in movies)
            {
                if (movie.CopiesAvailable == 0)
                    return BadRequest("No copies available");

                movie.CopiesAvailable--;

                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(newRental);
            }

            _context.SaveChanges();

            return Ok(rentalDto);
        }
    }
}
