using Server.Common;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Members
{
    public class AddMemberPayload : MemberPayloadBase
    {
        public AddMemberPayload(Member member)
            : base(member)
        {
        }

        public AddMemberPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}