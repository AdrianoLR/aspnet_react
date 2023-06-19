using aspnet_react.Commands;
using aspnet_react.DataStore;
using aspnet_react.Models;
using aspnet_react.Queries;
using MediatR;

namespace aspnet_react.Handler
{
    public class AddMoviesHandler : IRequestHandler<AddMovieCommand, Movies>
    {
        private readonly MoviesStore _moviesStore;
        public AddMoviesHandler(MoviesStore moviesStore) => _moviesStore = moviesStore;
        public async Task<Movies> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var result = await _moviesStore.AddMovie(request.moviesRequest);

            return result;

        }
        
    }
}
