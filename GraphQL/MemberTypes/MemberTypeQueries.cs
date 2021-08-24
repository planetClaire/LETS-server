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

namespace GraphQL.MemberTypes
{
    [ExtendObjectType("Query")]
    public class MemberTypeQueries
    {
        [UseGraphQLDbContext]
        public Task<List<MemberType>> GetMemberTypes([ScopedService] GraphQLDbContext context) => context.MemberTypes.ToListAsync();
        public Task<MemberType> GetMemberTypeAsync([GraphQLType(typeof(IdType))] Guid id, MemberTypeByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
