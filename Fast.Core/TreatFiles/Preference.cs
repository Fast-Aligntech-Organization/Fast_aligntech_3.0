using System.Collections.Generic;

namespace Fast.Core.TreatFiles;

public class Preference
{


  
    public ToothNumberingSystem? ToothNumberingSystem { get; set; }

    public DualArchPreference? DualArchPreference {get; set;}
    
    public Leveling Leveling {get; set;}
    
    public Attachments Attachments {get;set;}
    
    public bool? IPROnFirstClinCheck {get;set;}
    
    public bool? IPROnPermanentTeeth {get;set;}
    
    public bool IPROnPrimaryTeeth {get;set;}
    
    public IPRStaging IPRStaging {get;set;}
    
    public ToothStagingForArchExpansion? ToothStagingForArchExpansion {get;set;}
    
    public DelayStageToStartIPR DelayStageToStartIPR {get;set;}
    
    public DelayAttachmentPlacement DelayAttachmentPlacement {get;set;}
    
    public DelayStageOfExtraction DelayStageOfExtraction {get;set;}
    
    public PonticsForOpenSpaces PonticsForOpenSpaces {get;set;}
    //todo
    public PrecisionCutPreference PrecisionCutPreference {get;set;}
    
    public ArchExpansion ArchExpansion {get;set;}
    
    public ToothSizeDiscrepancy? ToothSizeDiscrepancy {get;set;}
    
    public PassiveAligners PassiveAligners {get;set;}
    
    public PassiveAlignersPreference? PassiveAlignersPreference {get;set;}
    
    public StageToRemoveAttachmentAtEnd StageToRemoveAttachmentAtEnd {get;set;}
    
    public AlignerTrimming? AlignerTrimming {get;set;}
    
    public bool? ApplyVirtualCChainMethod {get;set;}
    
    public OptimizedAttachmentVsPrecisionCut OptimizedAttachmentVsPrecisionCut {get;set;}
    
    public OptimizedAttachmentSizePreferenceClass OptimizedAttachmentSizePreference {get;set;}
    
    public TerminalMolarDistortion TerminalMolarDistortion {get;set;}
    




}



public class TerminalMolarDistortion: AttributesPrescriptionQuestionBase, INillable
{
    public bool IsNil {get;set;}
    
    public TerminalMolarDistortionTypeClass TerminalMolarDistortionTypeData {get;set;}
}

public class TerminalMolarDistortionTypeClass
{
    public RemoveDistalHalves RemoveDistalHalves {get;set;}

    public string DetailManually {get;set;}

    public string DoNotUse {get;set;}
}

public class RemoveDistalHalves
{
    public bool RemoveCompletelyIfNeeded {get;set;}
}

public class OptimizedAttachmentSizePreferenceClass: AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public string PrimitiveValue { get; set; }
    public bool IsNil { get; set; }

    public string Anterior { get; set; }
    public string Posterior { get; set; }
   
}



public class OptimizedAttachmentVsPrecisionCut:AttributesPrescriptionQuestionBase, INillable
{
    public bool IsNil { get; set; }

    public OptimizedAttachmentInsteadOfPrecisionCutA OptimizedAttachmentInsteadOfPrecisionCut { get; set; }
    
    public object PrecisionCutInsteadOfOptimizedAttachment { get; set; }

    public object PrecisionCutWithConventionalAttachment { get; set; }

  
}

public class OptimizedAttachmentInsteadOfPrecisionCutA 
{
     public bool ChangeCutoutToHook { get; set; }
}

public class ApplyVirtualCChainMethod: AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public string PrimitiveValue { get; set; }
    public bool IsNil { get; set; }
}

public class AlignerTrimmingClass: AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public string PrimitiveValue { get; set; }
    public bool IsNil { get; set; }
}

public class StageToRemoveAttachmentAtEnd: AttributesPrescriptionQuestionBase, INillable
{

    public bool DoNotRemoveAttachmentsTillTreatmentEnd { get; set; }

    public bool RemoveAttachmentsFromOvercorrectionStages { get; set; }

    public RemoveAttachmentsStagesBeforeTreatmentEndClass RemoveAttachmentsStagesBeforeTreatmentEnd { get; set; }

    public RemoveAttachmentsStagesBeforeOvercorrectionClass RemoveAttachmentsStagesBeforeOvercorrection { get; set; }

    public bool IsNil { get; set; }
}

public class RemoveAttachmentsStagesBeforeOvercorrectionClass: INillable
{
    public bool RemoveAttachmentsStagesBeforeOvercorrection { get; set; }
    
    public bool IsNil { get; set; }
}

public class RemoveAttachmentsStagesBeforeTreatmentEndClass: INillable
{
    public bool RemoveAttachmentsStagesBeforeTreatmentEnd { get; set; }

    public StagesBeforeClass StagesBefore { get; set; }
    public bool IsNil { get; set; }
} 

public class StagesBeforeClass: INillable
{
    public StagesBefore_Nillable_StagesBefore StagesBefore { get; set; }
    public bool IsNil { get; set; }
}

public class PassiveAlignersPreferenceClass: AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public string PrimitiveValue { get; set; }
    public bool IsNil { get; set; }
}

public class PassiveAligners: AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public string PrimitiveValue { get; set; }
    public bool IsNil { get; set; }
}



public class ArchExpansion 
{
    
    public ArchExpansionEnum ArchExpansionType { get; set; }
    public ArchExpansionAmount ExpansionAmount { get; set; }


}





public class PrecisionCutPreference: AttributesPrescriptionQuestionBase, INillable
{

    public MyClass MyClass11
    {
        get; set;
    }

    public MyClass MyClass111
    {
        get; set;
    }

    public MyClass MyMa
    {
        get; set;
    }

    public MyClass MyPatient
    {
        get; set;
    }

    public string StageToStartPrecisionCuts
    {
        get; set;
    }
    public bool IsNil { get; set; }

}



public class MyClass: INillable
{
    public bool IsNil { get; set; }
    
    public List<Tooth> Tooth { get; set; }
}

public class PonticsForOpenSpaces: AttributesPrescriptionQuestionBase, INillable
{
    public bool IsNil { get; set; }

    public string FullSizePonticsOnAnteriorPosterierSpaces
    {
        get; set;
    }

    public Other Other
    {
        get; set;
    }


}



public class Other
{

    
    public bool NoPonticsOnExtraction {get;set;}
    
    
    public bool NoPonticsOnPosterior {get;set;}
   


}

public class DelayStageOfExtraction : AttributesPrescriptionQuestionBase, INillable
{
   public bool IsNil { get; set; }
   public IDelayStageOfExtractionType_ExtractionBeginStage ExtractionBeginStage {get;set;}
    
}

public class DelayAttachmentPlacement:AttributesPrescriptionQuestionBase, INillable
{
   public bool IsNil { get; set; }
   public IDelayAttachmentPlacementType_AttachmentBeginStage AttachmentBeginStage {get;set;}
}



public class DelayStageToStartIPR: AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public bool IsNil { get; set; }
    public string PrimitiveValue { get; set; }

    public IDelayStageToStartIPRType_IPRBeginStage IPRBeginStage { get; set; }

}


public class IPRStaging : AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public bool IsNil
    {
        get; set;
    }
    public string PrimitiveValue
    {
        get; set;
    }
    public IIPRStagingType_IPRBeginStage IPRBeginStage
    {
        get; set;
    }
}





public class Attachments:AttributesPrescriptionQuestionBase, INillable
{
    public bool IsNil { get; set; }
    public List<Tooth> Tooth {get;set;}

}






public class Leveling: AttributesPrescriptionQuestionBase, INillable
{

    public IncisalEdges IncisalEdges {get;set;}
    public string GingivalMargins
    {
        get; set;
    }
    public bool IsNil { get; set; }
 
}



public class IncisalEdges
{
    public IncisalEdges_LevelAmount LevelAmount
    {
        get; set;
    }
}