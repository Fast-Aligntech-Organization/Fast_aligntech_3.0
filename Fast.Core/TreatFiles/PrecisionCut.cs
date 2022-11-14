namespace Fast.Core.TreatFiles;

public class PrecisionCut
{
    public string Id {get;set;}
   
    public ToothSurface CutToothSurface {get;set;}
   
    public CutType CutType {get;set;}
    
    public AttachmentBoostStatus CutStatus {get;set;}
   
}

public class CutType
{
   
    public Button Button {get;set;}
    
   
    public Slit Slit {get;set;}


}

public class Slit
{
    public CutSlitOrientation CutSlitOrientation {get;set;}
}

public class Button
{
    public CutButtonType CutButtonType {get;set;}

}