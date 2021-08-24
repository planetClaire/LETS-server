using System;

namespace GraphQL.Localities
{
    public record AddLocalityInput
    (
        Guid Id,
        string Name,
        string Postcode
    );
}
