using System;

namespace Server.MemberTypes
{
    public record AddMemberTypeInput
    (
        Guid Id,
        string Name
    );
}
