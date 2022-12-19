using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Response<UpdateStudentDto>>
    {
        private readonly ILogger<UpdateStudentCommandHandler> _logger;
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;

        public UpdateStudentCommandHandler(
            ILogger<UpdateStudentCommandHandler> logger,
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

        public async Task<Response<UpdateStudentDto>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            Student student = _mapper.Map<Student>(request);
            student.Id = _protector.Unprotect(student.Id);
            Student updatedStudent = await _repository.GetByIdAsync(student.Id);
            if (updatedStudent is null)
            {
                throw new NotFoundException("Student", student.Id);
            }
            _mapper.Map<Student, Student>(student, updatedStudent);
            await _repository.UpdateAsync(updatedStudent);
            UpdateStudentDto updateStudentDto = _mapper.Map<UpdateStudentDto>(updatedStudent);
            var response = new Response<UpdateStudentDto>(updateStudentDto);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
