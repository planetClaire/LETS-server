using Server.Common;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Notices
{
    public class NoticePayloadBase : Payload
    {
        protected NoticePayloadBase(Notice notice)
        {
            Notice = notice;
        }

        protected NoticePayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Notice? Notice { get; }
    }
}