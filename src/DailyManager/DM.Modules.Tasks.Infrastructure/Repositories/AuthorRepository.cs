﻿using DM.Modules.Tasks.Core.Aggregates;
using DM.Modules.Tasks.Core.Repositories;
using DM.Modules.Tasks.Infrastructure.Context;
using DM.Shared.Infrastructure.Repositories;

namespace DM.Modules.Tasks.Infrastructure.Repositories
{
    internal class AuthorRepository :
        CrudRepository<Author>,
        IAuthorRepository
    {
        public AuthorRepository(TaskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
