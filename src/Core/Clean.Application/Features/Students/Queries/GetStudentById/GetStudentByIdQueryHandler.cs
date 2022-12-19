using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Features.Students.Commands.UpdateStudent;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;

namespace Clean.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdDto>>
    {
        private readonly ILogger<GetStudentByIdQueryHandler> _logger;
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;

        public GetStudentByIdQueryHandler(
            ILogger<GetStudentByIdQueryHandler> logger,
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

        public async Task<Response<GetStudentByIdDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            string studentId = _protector.Unprotect(request.Id);
            Student student = await _repository.GetByIdAsync(studentId);
            if (student is null)
            {
                throw new NotFoundException("Student", request.Id);
            }
            GetStudentByIdDto studentDto = _mapper.Map<GetStudentByIdDto>(student);
            studentDto.Id = _protector.Protect(studentDto.Id);
            var response = new Response<GetStudentByIdDto>(studentDto);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
