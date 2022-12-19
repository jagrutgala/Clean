namespace Clean.Application.Features.Employees.Queries.GetEmployeeExport
{
    public class EmployeeExportFileVm
    {
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public string EmployeeExportFileName { get; set; }
    }
}