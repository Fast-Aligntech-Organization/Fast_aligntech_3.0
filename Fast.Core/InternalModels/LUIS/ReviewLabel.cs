using System.Collections.Generic;

namespace Fast.Core.InternalModels;

public class ReviewLabel
{
    public long Id
    {
        get; set;
    }
    public string Text
    {
        get; set;
    }
    public string IntentLabel
    {
        get; set;
    }
    public List<string> TokenizedText
    {
        get; set;
    }
    public List<Entitylabel> EntityLabels
    {
        get; set;
    }
    public List<Intentprediction> IntentPredictions
    {
        get; set;
    }
    public List<Entityprediction> EntityPredictions
    {
        get; set;
    }
    public object MultiIntentPredictions
    {
        get; set;
    }
}

public class EntitylabelTokenizer
{
    public string EntityName
    {
        get; set;
    }
    public int StartTokenIndex
    {
        get; set;
    }
    public int EndTokenIndex
    {
        get; set;
    }
}

public class Intentprediction
{
    public string Name
    {
        get; set;
    }
    public float Score
    {
        get; set;
    }
}

public class Entityprediction
{
    public string EntityName
    {
        get; set;
    }
    public int StartIndex
    {
        get; set;
    }
    public int EndIndex
    {
        get; set;
    }
    public string Phrase
    {
        get; set;
    }
}





