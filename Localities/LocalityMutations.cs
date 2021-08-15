using HotChocolate;
using HotChocolate.Types;
using Server.Entities;
using Server.Extensions;
using System;
using System.Threading.Tasks;

namespace Server.Localities
{
    [ExtendObjectType(Name = "Mutation")]
    public class LocalityMutations
    {
        [UseApplicationDbContext]
        public async Task<AddLocalityPayload> AddLocalityAsync(AddLocalityInput input, [ScopedService] ApplicationDbContext context)
        {
            var locality = new Locality
            {
                Id = input.Id,
                Name= input.Name,
                Postcode = input.Postcode
            };

            context.Localities.Add(locality);
            await context.SaveChangesAsync();

            return new AddLocalityPayload(locality);
        }
    }
}