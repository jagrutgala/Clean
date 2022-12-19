using Clean.Application.Features.Employees.Queries.GetEmployeeExport;
using Clean.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace Clean.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
        byte[] ExportEventsToCsv(List<EmployeeExportDto> employeeExportDtos);

    }
}
