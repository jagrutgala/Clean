using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Response<Unit>>
    {
        public string Id { get; set; }
    }
}
