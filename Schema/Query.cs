namespace Server.Schema
{
    public class Query
    {
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
