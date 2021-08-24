using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.Localities
{
    public class AddLocalityPayload : LocalityPayloadBase
    {
        public AddLocalityPayload(Locality locality)
            : base(locality)
        {
        }

        public AddLocalityPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}