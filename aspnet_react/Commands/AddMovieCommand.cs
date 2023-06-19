using aspnet_react.Models;
using MediatR;

namespace aspnet_react.Commands
{
    public record AddMovieCommand(MoviesRequest moviesRequest) : IRequest<Movies>;
}
