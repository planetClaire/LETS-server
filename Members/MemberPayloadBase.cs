using Server.Common;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Members
{
    public class MemberPayloadBase : Payload
    {
        protected MemberPayloadBase(Member member)
        {
            Member = member;
        }

        protected MemberPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Member? Member { get; }
    }
}