using Clean.Application.Features.Bottles.Commands.CreateBottle;
using Clean.Application.Features.Bottles.Commands.DeleteBottle;
using Clean.Application.Features.Bottles.Commands.UpdateBottle;
using Clean.Application.Features.Bottles.Queries.GetAllBottles;
using Clean.Application.Features.Bottles.Queries.GetBollteById;
using Clean.Application.Features.Students.Commands.DeleteStudent;
using Clean.Application.Features.Students.Commands.UpdateStudent;
using Clean.Application.Features.Students.Queries.GetAllStudents;
using Clean.Application.Features.Students.Queries.GetStudentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BottleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BottleController> _logger;

        public BottleController(
            IMediator mediator,
            ILogger<BottleController> logger
        )
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddBottle")]
        public async Task<IActionResult> AddBottle(CreateBottleCommand createBottleCommand)
        {
            _logger.LogInformation("AddBottle Initiated");
            var response = await _mediator.Send(createBottleCommand);
            _logger.LogInformation("AddBottle Completed");
            return Ok(response);
        }

        [HttpPut]
        [Route("EditBottle")]
        public async Task<IActionResult> EditBottle(UpdateBottleCommand updateBottleCommand)
        {
            _logger.LogInformation("EditBottle Initiated");
            var response = await _mediator.Send(updateBottleCommand);
            _logger.LogInformation("EditBottle Completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllBottles")]
        public async Task<IActionResult> GetAllBottles()
        {
            _logger.LogInformation("GetAllBottles Initiated");
            var response = await _mediator.Send(new GetAllBottlesQuery());
            _logger.LogInformation("GetAllBottles Completed");
            return Ok(response);
        }

        [HttpGet]
        [Route("GetBottleById")]
        public async Task<IActionResult> GetBottleById(string id)
        {
            _logger.LogInformation("GetBottleById Initiated");
            var response = await _mediator.Send(new GetBottleByIdQuery() { Id = id });
            _logger.LogInformation("GetBottleById Completed");
            return Ok(response);
        }

        [HttpDelete]
        [Route("RemoveBottle")]
        public async Task<IActionResult> RemoveBottle(DeleteBottleCommand deleteBottleCommand)
        {
            _logger.LogInformation("RemoveBottle Initiated");
            var response = await _mediator.Send(deleteBottleCommand);
            _logger.LogInformation("RemoveBottle Completed");
            return Ok(response);
        }
    }
}
