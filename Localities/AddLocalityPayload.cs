using Server.Common;
using Server.Entities;
using System.Collections.Generic;

namespace Server.Localities
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