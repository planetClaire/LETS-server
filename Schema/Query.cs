using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Schema
{
    public class Query
    {
        [UseApplicationDbContext]
        public Task<List<Member>> GetMembers([ScopedService] ApplicationDbContext context) => context.Members.ToListAsync();
    }
}
