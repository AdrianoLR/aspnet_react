﻿using aspnet_react.Models;
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
        public MoviesController(IMediator mediator) => _mediator = mediator;
        
        [HttpGet]
        public async Task<ActionResult> GetAllMovies()
        {
            var movies = await _mediator.Send(new GetMoviesQuery());

            return Ok(movies);
        }

        //[HttpGet]
        //[Route("id")]
        //public async Task<ActionResult> GetMovieId(int id)
        //{
        //    var movies = await _mediator.Send(new GetMoviesQuery());

        //    return Ok(movies);
        //}
    }
}
