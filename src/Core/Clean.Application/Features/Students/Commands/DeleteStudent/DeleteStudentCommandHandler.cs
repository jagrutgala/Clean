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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Response<Unit>>
    {
        private readonly ILogger<DeleteStudentCommandHandler> _logger;
        private readonly IStudentRepository _repository;
        private readonly IDataProtector _protector;

        public DeleteStudentCommandHandler(
            ILogger<DeleteStudentCommandHandler> logger,
            IStudentRepository repository,
            IDataProtectionProvider protectionProvider
        )
        {
            this._logger = logger;
            this._repository = repository;
            this._protector = protectionProvider.CreateProtector("");
        }

        public async Task<Response<Unit>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            string studentId = _protector.Unprotect(request.Id);
            Student updatedStudent = await _repository.GetByIdAsync(studentId);
            if (updatedStudent is null)
            {
                throw new NotFoundException("Student", request.Id);
            }
            await _repository.DeleteAsync(updatedStudent);
            var response = new Response<Unit>(Unit.Value);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
