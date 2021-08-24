using GraphQL.Common;
using GraphQL.Entities;
using System.Collections.Generic;

namespace GraphQL.Localities
{
    public class LocalityPayloadBase : Payload
    {
        protected LocalityPayloadBase(Locality locality)
        {
            Locality = locality;
        }

        protected LocalityPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Locality? Locality { get; }
    }
}