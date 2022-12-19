using AutoMapper;
using Clean.Application.Contracts.Infrastructure;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Models.Mail;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Response<CreateEmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateEmployeeCommandHandler(
            IEmployeeRepository employeeRepository,
            ILogger<CreateEmployeeCommandHandler> logger,
            IMapper mapper,
            IEmailService emailService
        )
        {
            this._employeeRepository = employeeRepository;
            this._logger = logger;
            this._mapper = mapper;
            this._emailService = emailService;
        }

        public async Task<Response<CreateEmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initalized");
            Employee employee = await _employeeRepository.AddAsync(_mapper.Map<Employee>(request));
            CreateEmployeeDto employeeDto = _mapper.Map<CreateEmployeeDto>(employee);
            var response = new Response<CreateEmployeeDto>(employeeDto);
            bool mailSent = await _emailService.SendEmail(GenerateEmail(employee.EmailAddress));
            _logger.LogInformation("Handler Completed");
            return response;
        }

        private Email GenerateEmail(string employeeEmail)
        {
            Email email = new Email()
            {
                To = employeeEmail,
                Body = $"Welcome to Boilerplate",
                Subject = "Congratulations on creating a new account"
            };
            return email;
        }
    }
}
