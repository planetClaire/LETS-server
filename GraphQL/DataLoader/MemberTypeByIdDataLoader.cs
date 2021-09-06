﻿using GreenDonut;
using Microsoft.EntityFrameworkCore;
using GraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.DataLoader
{
    public class MemberTypeByIdDataLoader : BatchDataLoader<Guid, MemberType>
    {
        private readonly IDbContextFactory<GraphQLDbContext> _dbContextFactory;

        public MemberTypeByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<GraphQLDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, MemberType>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using GraphQLDbContext dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.MemberTypes.Where(s => keys.Contains(s.Id)).ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}