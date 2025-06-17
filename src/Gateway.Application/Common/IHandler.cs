namespace Gateway.Application.Common;

public interface ICommandHandler<in TCommand, TResponse> where TResponse : Result
{
    Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface IQueryHandler<in TQuery, TResponse>
{
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}