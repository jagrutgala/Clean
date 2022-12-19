using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, Response<IEnumerable<EmployeeListDto>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(
            IEmployeeRepository employeeRepository,
            ILogger<GetAllEmployeesQueryHandler> logger,
            IMapper mapper
        )
        {
            this._employeeRepository = employeeRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task<Response<IEnumerable<EmployeeListDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initiated");
            var employees = await _employeeRepository.ListAllAsync();
            var employeeList = _mapper.Map<IEnumerable<EmployeeListDto>>(employees);
            var response = new Response<IEnumerable<EmployeeListDto>>(employeeList);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
