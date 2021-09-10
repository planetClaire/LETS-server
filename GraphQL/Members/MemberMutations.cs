using HotChocolate;
using HotChocolate.Types;
using GraphQL.Entities;
using GraphQL.Extensions;
using System.Threading.Tasks;
using System.Collections.Generic;
using GraphQL.Common;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Members
{
    [ExtendObjectType("Mutation")]
    public class MemberMutations
    {
        [UseGraphQLDbContext]
        public async Task<AddMemberPayload> AddMemberAsync(AddMemberInput input, [ScopedService] GraphQLDbContext context)
        {
            var existingMember = await context.Members.SingleOrDefaultAsync(e => e.Id == input.Id);
            if (existingMember != null)
            {
                return new AddMemberPayload(new List<UserError> { new UserError(UserErrorCode.DUPLICATE_MEMBER, input.Id.ToString()) });
            }

            var member = new Member
            {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Phone = input.Phone,
                LocalityId = input.LocalityId,
                StreetAddress = input.StreetAddress
            };

            context.Members.Add(member);
            await context.SaveChangesAsync();

            return new AddMemberPayload(member);
        }
    }
}