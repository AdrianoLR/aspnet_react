using aspnet_react.Commands;
using aspnet_react.DataStore;
using aspnet_react.Models;
using aspnet_react.Queries;
using MediatR;

namespace aspnet_react.Handler
{
    public class DeleteMovieByIdHandler : IRequestHandler<DeleteMovieByIdCommand, IResult>
    {
        private readonly MoviesStore _moviesStore;
        public DeleteMovieByIdHandler(MoviesStore moviesStore) => _moviesStore = moviesStore;
        public async Task<IResult> Handle(DeleteMovieByIdCommand request, CancellationToken cancellationToken)
        => await _moviesStore.DeleteMovieById(request.Id);
    }
}
