using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.Notices
{
    public class AddNoticePayload : NoticePayloadBase
    {
        public AddNoticePayload(Notice notice)
            : base(notice)
        {
        }

        public AddNoticePayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}