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

namespace GraphQL.Members
{
    [ExtendObjectType("Query")]
    public class MemberQueries
    {
        [UseApplicationDbContext]
        public Task<List<Member>> GetMembers([ScopedService] ApplicationDbContext context) => context.Members.ToListAsync();
        public Task<Member> GetMemberAsync([GraphQLType(typeof(IdType))] Guid id, MemberByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
