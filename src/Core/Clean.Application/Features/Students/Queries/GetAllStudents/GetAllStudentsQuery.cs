using Clean.Application.Features.Employees.Queries.GetAllEmployees;
using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQuery: IRequest<Response<IEnumerable<StudentListDto>>>
    {
    }
}
