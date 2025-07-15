using MRPeasy.API.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace MRPeasy.API.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}