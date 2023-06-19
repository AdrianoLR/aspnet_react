using aspnet_react.DataStore;
using aspnet_react.Models;
using aspnet_react.Queries;
using MediatR;

namespace aspnet_react.Handler
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, MoviesResponse>
    {
        private readonly MoviesStore _moviesStore;
        public GetMovieByIdHandler(MoviesStore moviesStore) => _moviesStore = moviesStore;
        public async Task<MoviesResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken) 
            => await _moviesStore.GetMovieId(request.Id);
        
    }
}
