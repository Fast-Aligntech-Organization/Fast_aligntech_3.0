namespace Fast.Core.TreatFiles;
public interface IAttributesPrescriptionQuestion
{
    string? Qid { get; set; }

    bool IsApplicable { get; set; }

    AttributeSource Source {get; set;}

}

public abstract class AttributesPrescriptionQuestionBase : IAttributesPrescriptionQuestion
{
    public string? Qid
    {
        get;
        set;
    }
    public bool IsApplicable
    {
        get;
        set;
    }
    public AttributeSource Source
    {
        get;
        set;
    }
}


