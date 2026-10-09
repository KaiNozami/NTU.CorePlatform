
using NTU.CorePlatform.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace NTU.CorePlatform.Domain.Entities.System.Categories;

public class Country : AggregateRoot<Guid>
{
    public string Name { get; private set; } = default!;

    protected Country() { }

    public Country(string name)
    {
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }
}
