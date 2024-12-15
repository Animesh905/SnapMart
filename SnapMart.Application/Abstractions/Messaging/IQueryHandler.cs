using SnapMart.Domain.Shared;

namespace SnapMart.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery,TResponse>
    where TResponse : IQuery<TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query,CancellationToken cancellationToken);
}
