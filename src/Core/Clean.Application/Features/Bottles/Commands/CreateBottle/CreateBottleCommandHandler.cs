using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Helper;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Features.Bottles.Commands.CreateBottle
{
    public class CreateBottleCommandHandler : IRequestHandler<CreateBottleCommand, Response<CreateBottleDto>>
    {
        private readonly ILogger<CreateBottleCommandHandler> _logger;
        private readonly IBottleRepository _repository;
        private readonly IMapper _mapper;

        public CreateBottleCommandHandler(
            ILogger<CreateBottleCommandHandler> logger,
            IBottleRepository repository,
            IMapper mapper
        )
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<Response<CreateBottleDto>> Handle(CreateBottleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            Bottle bottle = await _repository.AddAsync(_mapper.Map<Bottle>(request));
            CreateBottleDto bottleDto = _mapper.Map<CreateBottleDto>(bottle);
            bottleDto.Id = EncryptionDecryption.EncryptString(bottleDto.Id);
            var response = new Response<CreateBottleDto>(bottleDto);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
