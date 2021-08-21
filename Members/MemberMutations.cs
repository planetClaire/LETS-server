using HotChocolate;
using HotChocolate.Types;
using Server.Entities;
using Server.Extensions;
using System;
using System.Threading.Tasks;

namespace Server.Members
{
    [ExtendObjectType("Mutation")]
    public class MemberMutations
    {
        [UseApplicationDbContext]
        public async Task<AddMemberPayload> AddMemberAsync(AddMemberInput input, [ScopedService] ApplicationDbContext context)
        {
            var member = new Member
            {
                Id = input.Id,
                LocalityId = input.LocalityId,
                MemberTypeId = input.MemberTypeId,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Website = input.Website
            };

            context.Members.Add(member);
            await context.SaveChangesAsync();

            return new AddMemberPayload(member);
        }
    }
}