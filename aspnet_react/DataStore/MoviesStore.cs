using aspnet_react.Models;
using Supabase;
using Microsoft.AspNetCore.Mvc;
using Supabase.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

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
            var result = response.Models.ToList();

            if (result == null && result.Count == 0) { Results.NotFound(); }

            var moviesResponse = new List<MoviesResponse>();
            foreach (var item in result)
            {
                moviesResponse.Add(new MoviesResponse
                {
                    Title = item.Title,
                    Description = item.Description,
                    ItemType = item.ItemType,
                    Author = item.Director,
                    Date = item.Date,
                    Created_At = item.CreatedAt,
                });
            }

            return moviesResponse;

        }
        public async Task<MoviesResponse> GetMovieId(int id)
        {
            var moviesResponse = new MoviesResponse();

            try
            {

                var response = await _supabaseClient.From<Movies>().Where(n => n.Id == id).Get();

                var result = response.Models.FirstOrDefault();

                moviesResponse.Title = result.Title;
                moviesResponse.Description = result.Description;
                moviesResponse.ItemType = result.ItemType;
                moviesResponse.Author = result.Director;
                moviesResponse.Date = result.Date;
                moviesResponse.Created_At = result.CreatedAt;
                moviesResponse.CoverImageUrl = _supabaseClient.Storage.From("cover-images").GetPublicUrl($"movies-{id}.jpg");

            }
            catch (Exception ex)
            {
                throw new Exception($"Error to get movie by id:{ex.Message}");
            }

            return moviesResponse;
        }

        public async Task<Movies> AddMovie(MoviesRequest request)
        {
            var newMovies = new Movies();

            try
            {
                var movies = new Movies
                {
                    Title = request.Title,
                    ItemType = request.ItemType,
                    Date = request.Date,
                    CreatedAt = DateTime.Now,
                };

                var response = await _supabaseClient.From<Movies>().Insert(movies);
                newMovies = response.Models.First();

                using var memoryStream = new MemoryStream();
                await request.CoverImage.CopyToAsync(memoryStream);

                var lastIndexOfDot = request.CoverImage.FileName.LastIndexOf('.');
                string extension = request.CoverImage.FileName.Substring(lastIndexOfDot + 1);

                await _supabaseClient.Storage.From("cover-images").Upload(
                    memoryStream.ToArray(),
                    $"movies-{newMovies.Id}.{extension}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in the post method:{ex.Message}");
            }

            return newMovies;
        }

        public async Task<IResult> DeleteMovieById(int id)
        {
            try
            {
                await _supabaseClient.From<Movies>().Where(n => n.Id == id).Delete();
                
                await _supabaseClient.Storage.From("cover-images")
                    .Remove(new List<string> { $"movies-{id}.jpg"});
            }
            catch (Exception ex)
            {
                throw new Exception($"Error to DELETE movie by id:{ex.Message}");
            }
            return Results.NoContent();
        }
    }
}
