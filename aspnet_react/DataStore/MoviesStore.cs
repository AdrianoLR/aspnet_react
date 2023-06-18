using aspnet_react.Models;
using Supabase;
using Microsoft.AspNetCore.Mvc;
using Supabase.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace aspnet_react.DataStore
{
    public class MoviesStore
    {
        private readonly Client _supabaseClient;

        public MoviesStore(Supabase.Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async Task<IEnumerable<MoviesResponse>> GetAllMovies()
        {
            var response = await _supabaseClient.From<Movies>().Get();
            var result = response.Models.FirstOrDefault();

            if (result == null) { Results.NotFound(); }

            var moviesResponse = new MoviesResponse
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                ItemType = result.ItemType,
                Author = result.Director,
                Date = result.Date,
                Created_At = result.CreatedAt,
            };

            return (IEnumerable<MoviesResponse>)moviesResponse;

        }
        public async Task<MoviesResponse> GetMovieId(int id)
        {
            var response = await _supabaseClient.From<Movies>().Where(n => n.Id == id).Get();

            var result = response.Models.FirstOrDefault();

            var moviesResponse = new MoviesResponse
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                ItemType = result.ItemType,
                Author = result.Director,
                Date = result.Date,
                Created_At = result.CreatedAt,
            };

            return moviesResponse;
        }


        //[HttpPost]
        //public async Task<IActionResult> PostAsync(MoviesRequest request)
        //{
        //    var movies = new Movies
        //    {
        //        Title = request.Title,
        //        ItemType = request.ItemType,
        //        Date = request.Date,
        //        CreatedAt = DateTime.Now,
        //    };

        //    var response = await _client.From<Movies>().Insert(movies);
        //    var newMovies = response.Models.First();

        //    return Ok(newMovies.Id);
        //}
    }
}
