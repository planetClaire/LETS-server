using Server.Common;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Localities
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