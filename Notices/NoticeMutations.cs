using HotChocolate;
using HotChocolate.Types;
using Server.Entities;
using Server.Extensions;
using System.Threading.Tasks;

namespace Server.Notices
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