using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Server.DataLoader;
using Server.Entities;
using Server.Extensions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Notices
{
    [ExtendObjectType(Name = "Query")]
    public class NoticeQueries
    {
        [UseApplicationDbContext]
        public Task<List<Notice>> GetNotice([ScopedService] ApplicationDbContext context) => context.Notices.ToListAsync();
        public Task<Notice> GetNoticeAsync([GraphQLType(typeof(IdType))] Guid id, NoticeByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
