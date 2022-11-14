namespace Fast.Core.InternalModels;

public class LabelResult
{


    public ValueLabel Value
    {
        get; set;
    }
    public bool HasError
    {
        get; set;
    }
}

public class ValueLabel
{
    public string UtteranceText
    {
        get; set;
    }
    public int ExampleId
    {
        get; set;
    }
}



