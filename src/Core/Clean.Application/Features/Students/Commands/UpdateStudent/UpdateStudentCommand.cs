using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand: IRequest<Response<UpdateStudentDto>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
    }
}
