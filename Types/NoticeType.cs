using HotChocolate.Resolvers;
using HotChocolate.Types;
using Server.DataLoader;
using Server.Entities;

namespace Server.Types
{
    public class NoticeType : ObjectType<Notice>
    {
        protected override void Configure(IObjectTypeDescriptor<Notice> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<NoticeByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }

    }
}