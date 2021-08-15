using HotChocolate.Resolvers;
using HotChocolate.Types;
using Server.DataLoader;

namespace Server.Types
{
    public class MemberTypeType : ObjectType<Server.Entities.MemberType>
    {
        protected override void Configure(IObjectTypeDescriptor<Server.Entities.MemberType> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<MemberTypeByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }

    }
}