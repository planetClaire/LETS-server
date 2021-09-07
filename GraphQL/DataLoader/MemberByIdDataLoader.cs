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
    public class MemberByIdDataLoader : BatchDataLoader<string, Member>
    {
        private readonly IDbContextFactory<GraphQLDbContext> _dbContextFactory;

        public MemberByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<GraphQLDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<string, Member>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            await using GraphQLDbContext dbContext = _dbContextFactory.CreateDbContext();
            var foundMembers = await dbContext.Members.Where(m => keys.Contains(m.Id)).ToDictionaryAsync(m => m.Id, cancellationToken);
            var notFound = keys.Except(foundMembers.Keys).Select(key => new KeyValuePair<string, Member>(key, null));
            return new Dictionary<string, Member>(foundMembers.Concat(notFound));

        }
    }
}