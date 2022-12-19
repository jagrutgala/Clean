
using Clean.Application.Contracts.Persistence;
using Clean.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext, ILogger<Student> logger) : base(dbContext, logger)
        {
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await _dbContext.Set<Student>().FindAsync(id);
        }
    }
}
