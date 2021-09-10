using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.Members
{
    public class MemberPayloadBase : Payload
    {
        protected MemberPayloadBase(Member member)
        {
            Member = member;
        }

        protected MemberPayloadBase(IReadOnlyList<UserError> userErrors)
            : base(userErrors)
        {
        }

        public Member Member { get; }
    }
}