using Clean.Application.Responses;
using MediatR;

namespace Clean.Application.Features.Bottles.Queries.GetBollteById
{
    public class GetBottleByIdQuery : IRequest<Response<GetBottleByIdDto>>
    {
        public string Id { get; set; }
    }
}