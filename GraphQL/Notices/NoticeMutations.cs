using HotChocolate;
using HotChocolate.Types;
using GraphQL.Entities;
using GraphQL.Extensions;
using System.Threading.Tasks;

namespace GraphQL.Notices
{
    [ExtendObjectType("Mutation")]
    public class NoticeMutations
    {
        [UseGraphQLDbContext]
        public async Task<AddNoticePayload> AddNoticeAsync(AddNoticeInput input, [ScopedService] GraphQLDbContext context)
        {
            var notice = new Notice
            {
                Id = input.Id,
                Title = input.Title,
                MemberId = input.MemberId,
                NoticeTypeId = input.NoticeTypeId
            };

            context.Notices.Add(notice);
            await context.SaveChangesAsync();

            return new AddNoticePayload(notice);
        }
    }
}