using HotChocolate;
using HotChocolate.Types;
using GraphQL.Entities;
using GraphQL.Extensions;
using System.Threading.Tasks;

namespace GraphQL.Localities
{
    [ExtendObjectType("Mutation")]
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