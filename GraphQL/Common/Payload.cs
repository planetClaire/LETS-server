using System.Collections.Generic;

namespace GraphQL.Common
{
    public class Payload
    {
        protected Payload(IReadOnlyList<UserError> userErrors = null)
        {
            UserErrors = userErrors;
        }

        public IReadOnlyList<UserError> UserErrors { get; }
    }
}