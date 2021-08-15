using HotChocolate.Resolvers;
using HotChocolate.Types;
using Server.DataLoader;
using Server.Entities;

namespace Server.Types
{
    public class LocalityType : ObjectType<Locality>
    {
        protected override void Configure(IObjectTypeDescriptor<Locality> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<LocalityByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));
        }

    }
}