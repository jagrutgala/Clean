using AutoMapper;
using Clean.Application.Contracts.Infrastructure;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Features.Events.Queries.GetEventsExport;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Employees.Queries.GetEmployeeExport
{
    public class GetEmployeeExportQueryHandler : IRequestHandler<GetEmployeeExportQuery, EmployeeExportFileVm>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetEmployeeExportQueryHandler(
            IEmployeeRepository employeeRepository,
            ILogger<GetEmployeeExportQueryHandler> logger,
            IMapper mapper,
            ICsvExporter csvExporter
        )
        {
            this._employeeRepository = employeeRepository;
            this._logger = logger;
            this._mapper = mapper;
            this._csvExporter = csvExporter;
        }

        public async Task<EmployeeExportFileVm> Handle(GetEmployeeExportQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initiated");
            var employees = await _employeeRepository.ListAllAsync();
            var employeeList = _mapper.Map<IEnumerable<EmployeeExportDto>>(employees);
            var response = new Response<IEnumerable<EmployeeExportDto>>(employeeList);

            var allEvents = _mapper.Map<List<EmployeeExportDto>>((await _employeeRepository.ListAllAsync()));
            var fileData = _csvExporter.ExportEventsToCsv(allEvents);
            var employeeExportFileDto = new EmployeeExportFileVm() { ContentType = "text/csv", Data = fileData, EmployeeExportFileName = $"{Guid.NewGuid()}.csv" };
            _logger.LogInformation("Handler Completed");
            return employeeExportFileDto;
        }
    }
}
