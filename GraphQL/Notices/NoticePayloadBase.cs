using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.Notices
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

        public Notice Notice { get; }
    }
}