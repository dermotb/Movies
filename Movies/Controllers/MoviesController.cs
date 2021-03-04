using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        static List<Movie> theMovies = new List<Movie>()
        {
            new Movie(){MovieID = 001, Title="The Sound of Music", Genre=Genres.action, Cert=Certification.Universal, ReleaseDate=new DateTime(1999, 3, 12), AvgRating=10},
            new Movie(){MovieID = 002, Title="The Croots", Genre=Genres.animation, Cert=Certification.Universal, ReleaseDate=new DateTime(2015, 12, 16), AvgRating=4},
            new Movie(){MovieID = 003, Title="CSI: New York", Genre=Genres.crime, Cert=Certification.Universal, ReleaseDate=new DateTime(2010, 6, 1), AvgRating=7}
        };

        // GET: api/<Movie>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return theMovies.OrderByDescending(p=>p.ReleaseDate);
        }

        // GET api/<Movie>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Movie foundMovie = theMovies.FirstOrDefault(p => p.MovieID == id);
            if (foundMovie!=null)
            {
                return Ok(foundMovie);
            }
            return NotFound("No Movie with that ID");

        }

        // GET api/KeyW<Movie>/5
        [HttpGet("KeyW/{word}")]
        public IEnumerable<object> GetKewyW(string word)
        {
            return theMovies.Where(p => p.Title.Contains(" "+word+" ")).Select(p=>p.MovieID+" "+p.Title );
        }

        // POST api/<Movie>
        [HttpPost]
        public IActionResult Post([FromBody] Movie value)
        {
            if (ModelState.IsValid)
            {
                if (theMovies.Count == 0)
                {
                    value.MovieID = 0;
                }
                {
                    value.MovieID = theMovies[theMovies.Count - 1].MovieID + 1;
                }

                theMovies.Add(value);
                return Ok("Post added!");
            }
            else
            {
                return BadRequest("Posted Data Invalid!");
            }
        }

        // PUT api/<Movie>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Movie mv = theMovies.FirstOrDefault(p => p.MovieID == id);
            if (mv!=null)
            {
                mv.Title = value;
            }
        }

        // DELETE api/<Movie>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Movie mv = theMovies.FirstOrDefault(p => p.MovieID == id);
            if (mv!=null)
            {
                theMovies.Remove(mv);
            }    
        }
    }
}
