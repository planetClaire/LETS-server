using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.MemberTypes
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