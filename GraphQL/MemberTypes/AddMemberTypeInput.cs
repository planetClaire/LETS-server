using System;

namespace GraphQL.MemberTypes
{
    public record AddMemberTypeInput
    (
        Guid Id,
        string Name
    );
}
