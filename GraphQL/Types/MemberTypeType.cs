using HotChocolate.Resolvers;
using HotChocolate.Types;
using GraphQL.DataLoader;

namespace GraphQL.Types
{
    public class MemberTypeType : ObjectType<Entities.MemberType>
    {
        protected override void Configure(IObjectTypeDescriptor<Entities.MemberType> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<MemberTypeByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }

    }
}