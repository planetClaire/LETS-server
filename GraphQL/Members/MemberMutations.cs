﻿using HotChocolate;
using HotChocolate.Types;
using GraphQL.Entities;
using GraphQL.Extensions;
using System.Threading.Tasks;

namespace GraphQL.Members
{
    [ExtendObjectType("Mutation")]
    public class MemberMutations
    {
        [UseGraphQLDbContext]
        public async Task<AddMemberPayload> AddMemberAsync(AddMemberInput input, [ScopedService] GraphQLDbContext context)
        {
            var member = new Member
            {
                Id = input.Id,
                LocalityId = input.LocalityId,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Website = input.Website,
                Phone = input.Phone,
                StreetAddress = input.StreetAddress
            };

            context.Members.Add(member);
            await context.SaveChangesAsync();

            return new AddMemberPayload(member);
        }
    }
}