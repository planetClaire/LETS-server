using HotChocolate;
using HotChocolate.Types;
using GraphQL.Entities;
using GraphQL.Extensions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using HotChocolate.AspNetCore.Authorization;
using GraphQL.Common;
using System.Collections.Generic;

namespace GraphQL.Localities
{
    [ExtendObjectType("Mutation")]
    [Authorize(Roles = new[] { "admin" })]
    public class LocalityMutations
    {
        [UseGraphQLDbContext]
        public async Task<LocalityPayload> AddLocalityAsync(LocalityInput input, [ScopedService] GraphQLDbContext context)
        {
            var locality = new Locality
            {
                Id = input.Id,
                Name = input.Name,
                Postcode = input.Postcode
            };

            context.Localities.Add(locality);
            await context.SaveChangesAsync();

            return new LocalityPayload(locality);
        }

        [UseGraphQLDbContext]
        public async Task<LocalityPayload> UpdateLocalityAsync(LocalityInput input, [ScopedService] GraphQLDbContext context)
        {
            var locality = await context.Localities.SingleOrDefaultAsync(e => e.Id == input.Id);
            if (locality == null)
            {
                return new LocalityPayload(new List<UserError> { new UserError(UserErrorCode.LOCALITY_NOT_FOUND, input.Id.ToString()) });
            }
            if (!locality.Equals(input))
            {
                locality.Name = input.Name;
                locality.Postcode = input.Postcode;
                await context.SaveChangesAsync();
            }
            return new LocalityPayload(locality);
        }

        [UseGraphQLDbContext]
        public async Task<LocalityPayload> DeleteLocalityAsync(Guid id, [ScopedService] GraphQLDbContext context)
        {
            var locality = await context.Localities.FirstOrDefaultAsync(c => c.Id == id);

            if (locality is not null)
            {
                context.Localities.Remove(locality);
                await context.SaveChangesAsync();
                return new LocalityPayload(locality);
            }
            return new LocalityPayload(new List<UserError> { new UserError(UserErrorCode.LOCALITY_NOT_FOUND, id.ToString()) });
        }
    }
}