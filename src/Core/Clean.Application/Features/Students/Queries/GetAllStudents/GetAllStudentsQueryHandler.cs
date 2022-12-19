using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Features.Employees.Queries.GetAllEmployees;
using Clean.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, Response<IEnumerable<StudentListDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllStudentsQueryHandler> _logger;
        private readonly IStudentRepository _repository;
        private readonly IDataProtector _protector;

        public GetAllStudentsQueryHandler(
            IMapper mapper,
            ILogger<GetAllStudentsQueryHandler> logger,
            IStudentRepository repository,
            IDataProtectionProvider protectionProvider
        )
        {
            this._mapper = mapper;
            this._logger = logger;
            this._repository = repository;
            this._protector = protectionProvider.CreateProtector("");
        }

        public async Task<Response<IEnumerable<StudentListDto>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handler Initiated");
            var students = await _repository.ListAllAsync();
            IEnumerable<StudentListDto> studentList = _mapper.Map<IEnumerable<StudentListDto>>(students);
            foreach (StudentListDto stDto in studentList)
            {
                stDto.Id = _protector.Protect(stDto.Id);
            }
            var response = new Response<IEnumerable<StudentListDto>>(studentList);
            _logger.LogInformation("Handler Completed");
            return response;
        }
    }
}
