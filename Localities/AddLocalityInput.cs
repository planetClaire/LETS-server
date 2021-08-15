using System;

namespace Server.Localities
{
    public record AddLocalityInput
    (
        Guid Id,
        string Name,
        string Postcode
    );
}
