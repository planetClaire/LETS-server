using HotChocolate.Types;
using GraphQL.DataLoader;
using GraphQL.Entities;

namespace GraphQL.Types
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