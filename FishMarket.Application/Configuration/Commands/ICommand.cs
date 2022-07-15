using System;
using MediatR;

namespace FishMarket.Application.Configuration.Commands
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}