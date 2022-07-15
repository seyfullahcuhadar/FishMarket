using MediatR;

namespace FishMarket.Application.Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}