using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<Response<CreateStudentDto>>
    {
        public string Name { get; set; }
        public string Course { get; set; }

    }
}
