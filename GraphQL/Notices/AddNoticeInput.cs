using System;

namespace GraphQL.Notices
{
    public record AddNoticeInput
    (
        Guid Id,
        string Title,
        Guid MemberId,
        Guid NoticeTypeId
    );
}
