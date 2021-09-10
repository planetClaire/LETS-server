using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.Localities
{
    public class LocalityPayload : Payload
    {
        public LocalityPayload(Locality locality)
        {
            Locality = locality;
        }

        public LocalityPayload(IReadOnlyList<UserError> userErrors)
            : base(userErrors)
        {
        }

        public Locality Locality { get; }
    }
}