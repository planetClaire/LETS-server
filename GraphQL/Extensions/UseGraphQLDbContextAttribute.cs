﻿using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using System.Reflection;

namespace GraphQL.Extensions
{
    public class UseGraphQLDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member)
        {
            descriptor.UseDbContext<GraphQLDbContext>();
        }
    }
}