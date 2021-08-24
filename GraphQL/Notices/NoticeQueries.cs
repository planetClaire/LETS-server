using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using GraphQL.DataLoader;
using GraphQL.Entities;
using GraphQL.Extensions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL.Notices
{
    [ExtendObjectType("Query")]
    public class NoticeQueries
    {
        [UseGraphQLDbContext]
        public Task<List<Notice>> GetNotices([ScopedService] GraphQLDbContext context) => context.Notices.ToListAsync();
        public Task<Notice> GetNoticeAsync([GraphQLType(typeof(IdType))] Guid id, NoticeByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
