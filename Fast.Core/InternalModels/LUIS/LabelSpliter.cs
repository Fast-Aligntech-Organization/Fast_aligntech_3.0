using CsvHelper.Configuration.Attributes;

namespace Fast.Core.InternalModels;


public class LabelSpliter
{

    [CsvHelper.Configuration.Attributes.Index(0)]
    public string PID
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(1)]
    public string RawText
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(2)]
    public string Spaces
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(3)]
    public string KeepAttachments
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(4)]
    public string RemoveAttachments
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(5)]
    public string KeepLingualBar
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(6)]
    public string RemoveLingualBar
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(7)]
    public string BiteReset
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(8)]
    public string BiteSettings
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(9)]
    public string AlignerTrimming
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(10)]
    public string TeethExtraction
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(11)]
    public string ExpediteCases
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(12)]
    public string APRelations
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(13)]
    public string OrthoGeneralElement
    {
        get; set;
    }
    [CsvHelper.Configuration.Attributes.Index(14)]
    public string Buttons
    {
        get; set;
    }

    [CsvHelper.Configuration.Attributes.Index(15)]
    public string OnlyOneTreatedArc
    {
        get; set;
    }
}