using System;

namespace GraphQL.Members
{
    public record AddMemberInput
    (
        string Id,
        Guid LocalityId,
        Guid MemberTypeId,
        string FirstName,
        string LastName,
        string Website
    );
}
