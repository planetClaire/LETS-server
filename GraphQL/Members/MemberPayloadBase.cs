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

        protected MemberPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Member Member { get; }
    }
}