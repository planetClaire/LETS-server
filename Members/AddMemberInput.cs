using System;

namespace Server.Members
{
    public record AddMemberInput
    (
        Guid Id,
        Guid LocalityId,
        Guid MemberTypeId,
        string FirstName,
        string LastName,
        string? Website
    );
}
