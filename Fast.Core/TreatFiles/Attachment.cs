namespace Fast.Core.TreatFiles;

public class Attachment
{

    
    public string Id { get; set; }
    
    public AttachmentPurpose Purpose { get; set; }
   
    public AttachType Type { get; set; }
  
    public AttachmentBevel? Bevel { get; set; }
    
    public bool IsNilBevel { get; set; }
     
    public AttachmentOrientation? Orientation { get; set; }
    
    public bool IsNilOrientation { get; set; }
    
    public AttachmentLocation? Location { get; set; }
           
    public ToothSurface? Surface { get; set; }
   
    public string Size { get; set; }
    
    public AttachmentBoostStatus? Status { get; set; }
   




}

public class Size
{

    public Size_Units? Units {get;set;} 

}