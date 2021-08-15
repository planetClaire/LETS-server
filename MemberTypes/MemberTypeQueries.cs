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

namespace Server.MemberTypes
{
    [ExtendObjectType(Name = "Query")]
    public class MemberTypeQueries
    {
        [UseApplicationDbContext]
        public Task<List<MemberType>> GetMemberTypes([ScopedService] ApplicationDbContext context) => context.MemberTypes.ToListAsync();
        public Task<MemberType> GetMemberTypeAsync([GraphQLType(typeof(IdType))] Guid id, MemberTypeByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
