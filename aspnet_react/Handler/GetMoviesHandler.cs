using aspnet_react.DataStore;
using aspnet_react.Models;
using aspnet_react.Queries;
using MediatR;

namespace aspnet_react.Handler
{
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MoviesResponse>>
    {
        private readonly MoviesStore _moviesStore;
        public GetMoviesHandler(MoviesStore moviesStore) => _moviesStore = moviesStore;
        public async Task<IEnumerable<MoviesResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken) 
            => await _moviesStore.GetAllMovies();
        
    }
}
