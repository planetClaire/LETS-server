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

namespace Server.Localities
{
    [ExtendObjectType("Query")]
    public class LocalityQueries
    {
        [UseApplicationDbContext]
        public Task<List<Locality>> GetLocalities([ScopedService] ApplicationDbContext context) => context.Localities.ToListAsync();
        public Task<Locality> GetLocalityAsync([GraphQLType(typeof(IdType))] Guid id, LocalityByIdDataLoader dataLoader, CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
