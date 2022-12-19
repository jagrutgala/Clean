using Clean.Application.Contracts.Infrastructure;
using CsvHelper;
using Clean.Application.Features.Events.Queries.GetEventsExport;
using System.Globalization;
using Clean.Application.Features.Employees.Queries.GetEmployeeExport;

namespace Clean.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter,new CultureInfo(""));
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }

        public byte[] ExportEventsToCsv(List<EmployeeExportDto> employeeExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, new CultureInfo(""));
                csvWriter.WriteRecords(employeeExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
