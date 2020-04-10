﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDWithEF.Persistence.Configurations
{
    public class CollectionValueComparer<T> : ValueComparer<ICollection<T>>
    {

        // why? https://github.com/dotnet/efcore/issues/17471
        public CollectionValueComparer() : base((c1, c2) => c1.SequenceEqual(c2), c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), c => (ICollection<T>)c.ToHashSet())
        {

        }
    }
}
