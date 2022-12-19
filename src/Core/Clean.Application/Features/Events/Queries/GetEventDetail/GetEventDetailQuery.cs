using Clean.Application.Responses;
using MediatR;
using System;

namespace Clean.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
