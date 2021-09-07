using System;

namespace GraphQL.Notices
{
    public record AddNoticeInput
    (
        Guid Id,
        string Title,
        string MemberId,
        Guid NoticeTypeId
    );
}
