using System.Collections.Generic;

namespace Fast.Core.InternalModels;

public class EntityDefinition
{
    public string Name
    {
        get; set;
    }
    public List<Child> Children
    {
        get; set;
    }
}

public class Child
{
    public string Name
    {
        get; set;
    }
    public string InstanceOf
    {
        get; set;
    }
}

