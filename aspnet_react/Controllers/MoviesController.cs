using aspnet_react.Commands;
using aspnet_react.DataStore;
using aspnet_react.Models;
using aspnet_react.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace aspnet_react.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator, MoviesStore moviesStore)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMovies()
        {
            var movies = await _mediator.Send(new GetMoviesQuery());

            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetMoviewById")]
        public async Task<ActionResult> GetMovieId(int id)
        {
            var movies = await _mediator.Send(new GetMovieByIdQuery(id));

            return Ok(movies);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] MoviesRequest moviesRequest)
        {
            var result = await _mediator.Send(new AddMovieCommand(moviesRequest));
            return CreatedAtRoute("GetProductById", new { id = result.Id }, result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteMovieId(int id)
        {
            var movies = await _mediator.Send(new DeleteMovieByIdCommand(id));

            return Ok(movies);
        }
    }
}
