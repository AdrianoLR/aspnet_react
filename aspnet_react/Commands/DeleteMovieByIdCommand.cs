using aspnet_react.Models;
using MediatR;

namespace aspnet_react.Commands
{
    public record DeleteMovieByIdCommand(int Id) : IRequest<IResult>;
}