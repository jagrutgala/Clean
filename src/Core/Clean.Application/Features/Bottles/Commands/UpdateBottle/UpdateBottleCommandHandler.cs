using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Application.Helper;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Features.Bottles.Commands.UpdateBottle
{
    public class UpdateBottleCommandHandler : IRequestHandler<UpdateBottleCommand, Response<UpdateBottleDto>>
    {
        private readonly ILogger<UpdateBottleCommandHandler> _logger;
        private readonly IBottleRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBottleCommandHandler(
            ILogger<UpdateBottleCommandHandler> logger,
            IBottleRepository repository,
            IMapper mapper
        )
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<UpdateBottleDto>> Handle(UpdateBottleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            Bottle bottle = _mapper.Map<Bottle>(request);
            bottle.Id = EncryptionDecryption.DecryptString(bottle.Id);
            Bottle updatedBottle = await _repository.GetByIdAsync(bottle.Id);
            if (updatedBottle is null)
            {
                throw new NotFoundException("Bottle", bottle.Id);
            }
            _mapper.Map<Bottle, Bottle>(bottle, updatedBottle);
            await _repository.UpdateAsync(updatedBottle);
            UpdateBottleDto updateBottleDto = _mapper.Map<UpdateBottleDto>(updatedBottle);
            var response = new Response<UpdateBottleDto>(updateBottleDto);
            _logger.LogInformation("Handler Completed");
            return response; 
        }
    }
}
