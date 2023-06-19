using aspnet_react.Models;
using MediatR;

namespace aspnet_react.Queries
{
    public record GetMovieByIdQuery(int Id) : IRequest<MoviesResponse>;
}
