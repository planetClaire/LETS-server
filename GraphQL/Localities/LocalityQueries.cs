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

namespace GraphQL.Localities
{
    [ExtendObjectType("Query")]
    public class LocalityQueries
    {
        [UseApplicationDbContext]
        public Task<List<Locality>> GetLocalities([ScopedService] ApplicationDbContext context) => context.Localities.ToListAsync();
        public Task<Locality> GetLocalityAsync([GraphQLType(typeof(IdType))] Guid id, LocalityByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
