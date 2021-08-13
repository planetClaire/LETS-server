using System;

namespace Server.Schema
{
    public record AddMemberInput
    (
        Guid Id,
        string FirstName,
        string LastName,
        string? Website
    );
}
