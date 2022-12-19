﻿using Clean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Contracts.Persistence
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        public Task<Student> GetByIdAsync(string id);

    }
}
