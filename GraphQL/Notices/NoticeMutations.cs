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
        [UseApplicationDbContext]
        public async Task<AddNoticePayload> AddNoticeAsync(AddNoticeInput input, [ScopedService] ApplicationDbContext context)
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