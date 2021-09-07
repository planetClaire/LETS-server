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
    public class NoticeByIdDataLoader : BatchDataLoader<Guid, Notice>
    {
        private readonly IDbContextFactory<GraphQLDbContext> _dbContextFactory;

        public NoticeByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<GraphQLDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, Notice>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            await using GraphQLDbContext dbContext = _dbContextFactory.CreateDbContext();

            var foundNotices = await dbContext.Notices.Where(n => keys.Contains(n.Id)).ToDictionaryAsync(n => n.Id, cancellationToken);
            var notFound = keys.Except(foundNotices.Keys).Select(key => new KeyValuePair<Guid, Notice>(key, null));
            return new Dictionary<Guid, Notice>(foundNotices.Concat(notFound));
        }
    }
}