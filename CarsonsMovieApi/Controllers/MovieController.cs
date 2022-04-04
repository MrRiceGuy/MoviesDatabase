using CarsonsMovieApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsonsMovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _dbContext;

        public MovieController(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]

        public IActionResult AddMovie([FromBody]Movie movie)
        {
            _dbContext.Movies.Add(movie);

            _dbContext.SaveChanges();

            return Ok(movie);

        }

        [HttpPut]

        public IActionResult UpdateMovie([FromBody] Movie movie)
        {
            _dbContext.Movies.Update(movie);

            _dbContext.SaveChanges();

            return Ok(movie);

        }

        [HttpGet]

        public IActionResult GetAllMovies()
        {
            var movies = _dbContext.Movies.ToList();

            return Ok(movies);
        }


        [HttpGet("{id}")]

        public IActionResult GetMovieById([FromRoute] int id)
        {

            var movie = _dbContext.Movies.Find(id);
            return Ok(movie);

        }

        [HttpGet("category/{category}")]

        public IActionResult GetMoviesByCategory([FromRoute] string category)
        {
            var movie = _dbContext.Movies.Where(m => m.Genre == category);//idk what this is.
            return Ok(movie);
        }


        //public IActionResult GetRandomMoviesList([FromRoute])
        //{
        //    Random rando = new Random();
        //    var movies = _dbContext.Movies.ToList();

        //    int randomNum = rando.Next(movies.Count);
        //    var randomMovie = movies[randomNum];
        //    return Ok(randomMovie);
        //}

        [HttpGet("id/{category}")]

        public IActionResult GetRandomMoviesByCategory([FromRoute] string category)
        {
            Random rando = new Random();
            var movies = _dbContext.Movies.ToList();

            int randomNum = rando.Next(movies.Count);
            var randomMovie = movies[randomNum];
            return Ok(randomMovie);
        }

        //public IActionResult GetListOfCatagories()
        //{


           


        //    Random rando = new Random();
        //    var movies = _dbContext.Movies.ToList();

        //    int randomNum = rando.Next(movies.Count);
        //    var randomMovie = movies[randomNum];
        //    return Ok(randomMovie);
        //}
    }
}
