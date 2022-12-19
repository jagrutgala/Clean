using Clean.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Clean.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
