using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Helper;
using Clean.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Features.Bottles.Queries.GetAllBottles
{
    public class GetAllBottlesQueryHandler : IRequestHandler<GetAllBottlesQuery, Response<IEnumerable<BottleListDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllBottlesQueryHandler> _logger;
        private readonly IBottleRepository _repository;

        public GetAllBottlesQueryHandler(
            IMapper mapper,
            ILogger<GetAllBottlesQueryHandler> logger,
            IBottleRepository repository
        )
        {
            this._mapper = mapper;
            this._logger = logger;
            this._repository = repository;
        }

        public async Task<Response<IEnumerable<BottleListDto>>> Handle(GetAllBottlesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initiated");
            var bottles = await _repository.ListAllAsync();
            IEnumerable<BottleListDto> bottleList = _mapper.Map<IEnumerable<BottleListDto>>(bottles);
            foreach (BottleListDto bDto in bottleList)
            {
                bDto.Id = EncryptionDecryption.EncryptString(bDto.Id);
            }
            var response = new Response<IEnumerable<BottleListDto>>(bottleList);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
