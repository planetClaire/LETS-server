using Server.Common;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Notices
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