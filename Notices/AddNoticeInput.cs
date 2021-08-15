using System;

namespace Server.Notices
{
    public record AddNoticeInput
    (
        Guid Id,
        string Title,
        Guid MemberId,
        Guid NoticeTypeId
    );
}
