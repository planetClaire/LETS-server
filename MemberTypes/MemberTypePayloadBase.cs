using Server.Common;
using Server.Entities;
using System.Collections.Generic;

namespace Server.MemberTypes
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