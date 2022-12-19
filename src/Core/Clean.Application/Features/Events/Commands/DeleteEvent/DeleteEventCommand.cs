using MediatR;
using System;

namespace Clean.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand: IRequest
    {
        public string EventId { get; set; }
    }
}
