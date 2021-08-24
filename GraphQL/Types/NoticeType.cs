using HotChocolate.Resolvers;
using HotChocolate.Types;
using GraphQL.DataLoader;
using GraphQL.Entities;

namespace GraphQL.Types
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