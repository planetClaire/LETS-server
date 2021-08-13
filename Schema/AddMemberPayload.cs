using Server.Entities;

namespace Server.Schema
{
    public class AddMemberPayload
    {
        public Member Member { get; }
        public AddMemberPayload(Member member)
        {
            Member = member;
        }
    }
}
