using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Response<CreateStudentDto>>
    {
        private readonly ILogger<CreateStudentCommandHandler> _logger;
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;

        public CreateStudentCommandHandler(
            ILogger<CreateStudentCommandHandler> logger,
            IStudentRepository repository,
            IMapper mapper,
            IDataProtectionProvider protectionProvider
        )
        {
            this._logger = logger;
            this._repository = repository;
            this._mapper = mapper;
            this._protector = protectionProvider.CreateProtector("");
        }
        public async Task<Response<CreateStudentDto>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            Student student = await _repository.AddAsync(_mapper.Map<Student>(request));
            CreateStudentDto studentDto = _mapper.Map<CreateStudentDto>(student);
            studentDto.Id = _protector.Protect(studentDto.Id);
            var response = new Response<CreateStudentDto>(studentDto, "Created student");
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
