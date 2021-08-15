using Server.Common;
using Server.Entities;
using System.Collections.Generic;

namespace Server.MemberTypes
{
    public class AddMemberTypePayload : MemberTypePayloadBase
    {
        public AddMemberTypePayload(MemberType memberType)
            : base(memberType)
        {
        }

        public AddMemberTypePayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}