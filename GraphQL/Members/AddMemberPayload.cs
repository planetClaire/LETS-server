using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.Members
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