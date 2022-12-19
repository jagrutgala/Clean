using Clean.Application.Features.Employees.Commands.CreateEmployee;
using Clean.Application.Features.Employees.Queries.GetAllEmployees;
using Clean.Application.Features.Employees.Queries.GetEmployeeExport;
using Clean.Application.Features.Events.Queries.GetEventsExport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.v2
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
            IMediator mediator,
            ILogger<EmployeeController> logger
        )
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeCommand createEmployeeCommand)
        {
            _logger.LogInformation("AddEmployee Initiated");
            var response = await _mediator.Send(createEmployeeCommand);
            _logger.LogInformation("AddEmployee Completed");
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            _logger.LogInformation("GetAllEmployees Initiated");
            var response = await _mediator.Send(new GetAllEmployeesQuery());
            _logger.LogInformation("GetAllEmployees Completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetEmployeExport()
        {
            _logger.LogInformation("GetEmployeExport Initiated");
            var response = await _mediator.Send(new GetEmployeeExportQuery());
            _logger.LogInformation("GetEmployeExport Completed");
            return File(response.Data, response.ContentType, response.EmployeeExportFileName);
        }
    }
}
