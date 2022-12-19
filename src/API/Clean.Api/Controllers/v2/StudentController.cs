using Clean.Application.Features.Employees.Commands.CreateEmployee;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Features.Students.Commands.DeleteStudent;
using Clean.Application.Features.Students.Commands.UpdateStudent;
using Clean.Application.Features.Students.Queries.GetAllStudents;
using Clean.Application.Features.Students.Queries.GetStudentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.v2
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentController> _logger;

        public StudentController(
            IMediator mediator,
            ILogger<StudentController> logger
        )
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddBottle")]
        public async Task<IActionResult> AddStudent(CreateStudentCommand createStudentCommand)
        {
            _logger.LogInformation("AddBottle Initiated");
            var response = await _mediator.Send(createStudentCommand);
            _logger.LogInformation("AddBottle Completed");
            return Ok(response);
        }

        [HttpPut]
        [Route("EditBottle")]
        public async Task<IActionResult> EditStudent(UpdateStudentCommand updateStudentCommand)
        {
            _logger.LogInformation("EditBottle Initiated");
            var response = await _mediator.Send(updateStudentCommand);
            _logger.LogInformation("EditBottle Completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllBottles")]
        public async Task<IActionResult> GetAllStudents()
        {
            _logger.LogInformation("GetAllBottles Initiated");
            var response = await _mediator.Send(new GetAllStudentsQuery());
            _logger.LogInformation("GetAllBottles Completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("GetBottleById")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            _logger.LogInformation("GetBottleById Initiated");
            var response = await _mediator.Send(new GetStudentByIdQuery() { Id = id });
            _logger.LogInformation("GetBottleById Completed");
            return Ok(response);
        }

        [HttpDelete]
        [Route("RemoveBottle")]
        public async Task<IActionResult> RemoveStudent(DeleteStudentCommand deleteStudentCommand)
        {
            _logger.LogInformation("RemoveBottle Initiated");
            var response = await _mediator.Send(deleteStudentCommand);
            _logger.LogInformation("RemoveBottle Completed");
            return Ok(response);
        }
    }
}
