using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.MemberTypes
{
    public class MemberTypePayloadBase : Payload
    {
        protected MemberTypePayloadBase(MemberType memberType)
        {
            MemberType = memberType;
        }

        protected MemberTypePayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public MemberType? MemberType { get; }
    }
}