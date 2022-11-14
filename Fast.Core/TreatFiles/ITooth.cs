using System.Collections.Generic;

namespace Fast.Core.TreatFiles;
public interface ITooth
{

    string Id { get; set; }


}


public class Tooth : ITooth
{
   

    public Tooth()
    {
        //Attachments = new();
        //precisionCuts = new();
    }

    public string Id { get; set; } 

    public string Space { get; set; }

    public List<PrecisionCut> PrecisionCut {get; set; }

    public List<Attachment> Attachment {get; set; }

    //[JsonIgnore]
    //public List<Attachment> Attachments { get; set; }
    //[JsonIgnore]
    //public List<PrecisionCut> precisionCuts { get; set; }

}
