using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<Response<IEnumerable<EmployeeListDto>>>
    {
    }
}
