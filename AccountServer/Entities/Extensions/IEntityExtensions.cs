﻿using AccountServer.Entities;

namespace Entities.Extensions;

public static class IEntityExtensions
{
    public static bool IsObjectNull(this IEntity entity)
    {
        return entity == null;
    }

    public static bool IsEmptyObject(this IEntity entity)
    {
        return entity.Id.Equals(Guid.Empty);
    }
}