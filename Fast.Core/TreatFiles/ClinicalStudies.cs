using System.Collections.Generic;

namespace Fast.Core.TreatFiles;

public class ClinicalStudies
{
    public ClinicalStudies()
    {
        Study = new();
    }

    public List<Study> Study  {get; set;}


}

public class Study
{

    public bool Enrolled {get; set;}

    public bool Recommended {get; set;}

    public string ID {get; set;}

    public string Name {get; set;}



}