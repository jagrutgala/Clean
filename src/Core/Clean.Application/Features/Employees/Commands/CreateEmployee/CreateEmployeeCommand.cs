using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Response<CreateEmployeeDto>>
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
    }
}
