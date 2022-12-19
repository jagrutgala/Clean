using Clean.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Clean.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery: IRequest<Response<IEnumerable<CategoryEventListVm>>>
    {
        public bool IncludeHistory { get; set; }
    }
}
