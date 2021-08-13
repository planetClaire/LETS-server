using HotChocolate;
using Server.Entities;
using System.Linq;

namespace Server.Schema
{
    public class Query
    {
        public IQueryable<Member> GetMembers([Service] ApplicationDbContext context) => context.Members;
        public Notice GetNotice() =>
            new Notice
            {
                Title = "C# in depth.",
                Member = new Member
                {
                    FirstName = "Jon"
                }
            };
    }
}
