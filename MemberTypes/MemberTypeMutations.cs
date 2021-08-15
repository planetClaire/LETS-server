using HotChocolate;
using HotChocolate.Types;
using Server.Entities;
using Server.Extensions;
using System.Threading.Tasks;

namespace Server.MemberTypes
{
    [ExtendObjectType(Name = "Mutation")]
    public class MemberTypeMutations
    {
        [UseApplicationDbContext]
        public async Task<AddMemberTypePayload> AddMemberTypeAsync(AddMemberTypeInput input, [ScopedService] ApplicationDbContext context)
        {
            var memberType  = new MemberType
            {
                Id = input.Id,
                Name = input.Name
            };

            context.MemberTypes.Add(memberType);
            await context.SaveChangesAsync();

            return new AddMemberTypePayload(memberType);
        }
    }
}