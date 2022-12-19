using Clean.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Clean.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
