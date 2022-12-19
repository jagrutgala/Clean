using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Application.Helper;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Features.Bottles.Queries.GetBollteById
{
    public class GetBottleByIdQueryHandler : IRequestHandler<GetBottleByIdQuery, Response<GetBottleByIdDto>>
    {
        private readonly ILogger<GetBottleByIdQueryHandler> _logger;
        private readonly IBottleRepository _repository;
        private readonly IMapper _mapper;

        public GetBottleByIdQueryHandler(
            ILogger<GetBottleByIdQueryHandler> logger,
            IBottleRepository repository,
            IMapper mapper
        )
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Response<GetBottleByIdDto>> Handle(GetBottleByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            string bottleId = EncryptionDecryption.DecryptString(request.Id);
            Bottle bottle = await _repository.GetByIdAsync(bottleId);
            if (bottle is null)
            {
                throw new NotFoundException("Bottle", request.Id);
            }
            GetBottleByIdDto bottleDto = _mapper.Map<GetBottleByIdDto>(bottle);
            bottleDto.Id = EncryptionDecryption.EncryptString(bottleDto.Id);
            var response = new Response<GetBottleByIdDto>(bottleDto);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
