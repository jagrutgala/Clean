using Clean.Application.Contracts.Persistence;
using Clean.Application.Models.Mail;
using Clean.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext, ILogger<Employee> logger) : base(dbContext, logger)
        {
        }
    }
}
