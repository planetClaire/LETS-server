using System.ComponentModel;

namespace GraphQL.Common
{
    public class UserError
    {
        public UserError(UserErrorCode code, string field = null)
        {
            Code = code;
            Field = field;
        }
        public UserErrorCode Code { get; }
        public string Message => Code.GetDescription();
        public string Field { get; }

    }

    public enum UserErrorCode
    {
        [Description("Locality not found")]
        LOCALITY_NOT_FOUND,
        [Description("Member already exists")]
        DUPLICATE_MEMBER

    }

}
