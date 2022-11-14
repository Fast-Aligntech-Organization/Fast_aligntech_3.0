using System;

namespace Fast.Core.InternalModels;

public class TrainingVersionResult
{
    public string ModelId
    {
        get; set;
    }
    public Details Details
    {
        get; set;
    }
}

public class Details
{
    public int StatusId
    {
        get; set;
    }
    public string Status
    {
        get; set;
    }
    public int ExampleCount
    {
        get; set;
    }
    public DateTime TrainingDateTime
    {
        get; set;
    }
}
