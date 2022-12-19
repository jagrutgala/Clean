using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Application.Helper;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Features.Bottles.Commands.DeleteBottle
{
    public class DeleteBottleCommandHandler : IRequestHandler<DeleteBottleCommand, Response<Unit>>
    {
        private readonly ILogger<DeleteBottleCommandHandler> _logger;
        private readonly IBottleRepository _repository;

        public DeleteBottleCommandHandler(
            ILogger<DeleteBottleCommandHandler> logger,
            IBottleRepository repository
        )
        {
            this._logger = logger;
            this._repository = repository;
        }

        public async Task<Response<Unit>> Handle(DeleteBottleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            string bottleId = EncryptionDecryption.DecryptString(request.Id);
            Bottle updatedBottle = await _repository.GetByIdAsync(bottleId);
            if (updatedBottle is null)
            {
                throw new NotFoundException("Bottle", request.Id);
            }
            await _repository.DeleteAsync(updatedBottle);
            var response = new Response<Unit>(Unit.Value);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
