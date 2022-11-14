using System.Collections.Generic;

namespace Fast.Core.InternalModels;


public class EntityInfo
{
    public string Id
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public int TypeId
    {
        get; set;
    }
    public string ReadableType
    {
        get; set;
    }
    public List<Sublist> SubLists
    {
        get; set;
    }
    public List<Role> Roles
    {
        get; set;
    }
}

public class Sublist
{
    public int Id
    {
        get; set;
    }
    public string CanonicalForm
    {
        get; set;
    }
    public List<string> List
    {
        get; set;
    }
}

public class Role
{
    public string Id
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
}

