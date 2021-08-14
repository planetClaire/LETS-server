using HotChocolate;
using Server.Entities;
using Server.Extensions;
using System.Threading.Tasks;

namespace Server.Schema
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddMemberPayload> AddMemberAsync(AddMemberInput input, [ScopedService] ApplicationDbContext context)
        {
            var member = new Member
            {
                Id = input.Id,
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