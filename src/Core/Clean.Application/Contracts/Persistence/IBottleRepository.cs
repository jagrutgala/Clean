using Clean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Contracts.Persistence
{
    public interface IBottleRepository : IAsyncRepository<Bottle>
    {
        public Task<Bottle> GetByIdAsync(string id);

    }
}
