using Clean.Application.Contracts.Persistence;
using Clean.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Clean.Persistence.Repositories
{
    public class BottleRepository : BaseRepository<Bottle>, IBottleRepository
    {
        public BottleRepository(ApplicationDbContext dbContext, ILogger<Bottle> logger) : base(dbContext, logger)
        {
        }

        public async Task<Bottle> GetByIdAsync(string id)
        {
            return await _dbContext.Set<Bottle>().FindAsync(id);
        }
    }
}
