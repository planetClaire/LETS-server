using System;

namespace GraphQL.Localities
{
    public record LocalityInput
    (
        Guid Id,
        string Name,
        string Postcode
    );
}
