using Clean.Application.Responses;
using MediatR;

namespace Clean.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentByIdDto>>
    {
        public string Id { get; set; }
    }
}