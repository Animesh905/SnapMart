using MediatR;
using SnapMart.Domain.Shared;

namespace SnapMart.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}

