using GreenDonut;
using Microsoft.EntityFrameworkCore;
using GraphQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.DataLoader
{
    public class LocalityByIdDataLoader : BatchDataLoader<Guid, Locality>
    {
        private readonly IDbContextFactory<GraphQLDbContext> _dbContextFactory;

        public LocalityByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<GraphQLDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, Locality>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using GraphQLDbContext dbContext = _dbContextFactory.CreateDbContext();
            var foundLocalities = await dbContext.Localities.Where(l => keys.Contains(l.Id)).ToDictionaryAsync(l => l.Id, cancellationToken);
            var notFound = keys.Except(foundLocalities.Keys).Select(key => new KeyValuePair<Guid, Locality>(key, null));
            return new Dictionary<Guid, Locality>(foundLocalities.Concat(notFound));
        }
    }
}