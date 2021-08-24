using HotChocolate.Resolvers;
using HotChocolate.Types;
using GraphQL.DataLoader;
using GraphQL.Entities;

namespace GraphQL.Types
{
    public class MemberType : ObjectType<Member>
    {
        protected override void Configure(IObjectTypeDescriptor<Member> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<MemberByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }
    }
}