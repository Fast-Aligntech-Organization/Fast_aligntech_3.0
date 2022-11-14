
using System.Collections.Generic;
namespace Fast.Core.TreatFiles;

public class PrescriptionQuestion
{

 public PrimaryFromQuestion? PrimaryQuestion { get; set; }

 public object SecondaryProduct {get; set; }

   public object RetentionProducts {get; set; }


}

public class PrimaryFromQuestion: Preference, ICommonFormQuestions
{

    public string DentalRecords
    {
        get;
        set;
    }

    public DentalRecordsOrigin DentalRecordsOrigin
    {
        get;
        set;
    }

    public ArchLevelOverBite ArchLevelOverBite { get; set; }
   
    public TreatedArches TreatedArches { get; set; }

    public PatientsChiefConcernClass PatientsChiefConcern { get; set; }

    public TeethToBeTreatedClass TeethToBeTreated { get; set; }

    public DoNotMoveTeeth DoNotMoveTeeth { get; set; }

    public TeethPermittedForAttachments TeethPermittedForAttachments { get; set; }


    public APRelation APRelation { get; set; }

    public OverJetClass OverJet { get; set; }
   

    //public OverBite OverBite { get; set; }

    //public Midline Midline { get; set; }

    //public SmileArchitect SmileArchitect { get; set; }

    //public PosteriorCrossBite PosteriorCrossBite { get; set; }

    //public ArchLengthDiscrepancy ArchLengthDiscrepancy { get; set; }

    //public Crowding Crowding { get; set; }

    //public Extraction Extraction { get; set; }

    //public SpacesForCanineAnd2ndBi SpacesForCanineAnd2ndBi { get; set; } 

    //public TeenSecondMolarTabs TeenSecondMolarTabs { get; set; }

    //public SpecialInstructions SpecialInstructions { get; set; }

    //public BiteRampsUpper BiteRampsUpper { get; set; }

    //public OptimizedAttachmentVsPrecisionCutTypeClass OptimizedAttachmentVsPrecisionCut { get; set; }

    //public TreatmentObjectiveClass TreatmentObjective { get; set; }

    //public RxFormTemplate RxFormTemplate { get; set; }

    //public RestorationsType Restorations { get; set; }

    //public ChiefConcernType ChiefConcern { get; set; }

}

public class OverJetClass : AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public bool IsNil
    {
        get;
        set;
    }
    public string PrimitiveValue
    {
        get;
        set;
    }
}

public class APRelation: AttributesPrescriptionQuestionBase, INillable
{
    public bool IsNil { get; set; }
    public APRelationshipType APRelationshipType { get; set; }

    public APRelationshipOptions APRelationshipOptions { get; set; }

}

public class APRelationshipType 
{
    public APRelationshipEnum Left { get; set; }
    public APRelationshipEnum Right { get; set; }
}

public class APRelationshipOptions:INillable
{
    public bool IsNil { get; set; }

    public ToothMovementOptions ToothMovementOptions { get; set; }

    public string OrthognathicSurgicalSetup { get; set; }

   public InvisalignWithMandibularAdvancement InvisalignWithMandibularAdvancement { get; set; }

    public object InvisalignDistalizer { get; set; }


}

public class InvisalignWithMandibularAdvancement
{
    public EndMAPhasePosition EndMAPhasePosition {get; set;}

    public AdvancementStagingJumps AdvancementStagingJumps {get; set;}

    public AsymmetricalMovementLowerArch AsymmetricalMovementLowerArch { get; set; }

    public MACorrectionSimulation MACorrectionSimulation { get; set; }

}

public class MACorrectionSimulation
{
    public bool PrecisionCuts { get; set; }
}

public class ToothMovementOptions:INillable
{
    public bool IsNil { get; set; }
    public string  IsMovement { get; set; }
    public bool IsNoMovement { get; set; }
    public ToothMovementOptionsUpto14Stages ToothMovementOptionsUpto14Stages {get; set;}


}

public class ToothMovementOptionsUpto14Stages : INillable
{
    public bool IsNil
    {
        get;
        set;
    }

     public string PosteriorIPR  {get;set;}

     public string Distalization {get;set; }
}

public class TeethPermittedForAttachments: AttributesPrescriptionQuestionBase, INillable
{
    public bool IsNil { get; set; }
    public TeethPermittedForAttachmentTypeDataClass TeethPermittedForAttachmentTypeData { get; set; }
}

public class TeethPermittedForAttachmentTypeDataClass
{
    public string AnyTeeth { get; set; }
    public ToothList DoNotPutTheseTeeth { get; set; }
}


public class DoNotMoveTeeth: AttributesPrescriptionQuestionBase, INillable
{
    public DoNotMoveTeethType DoNotMoveTeethTypeData { get; set; }
    public bool IsNil { get; set; }
}

public class DoNotMoveTeethType
{
    public string None { get; set; }

    public ToothList  TheseTeeth { get; set; }


}

public class TeethToBeTreatedClass: AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public string PrimitiveValue { get; set; }
    public bool IsNil { get; set; }
    

}



public class PatientsChiefConcernClass : AttributesPrescriptionQuestionBase, INillable, IPrimitive
{
    public string PrimitiveValue { get; set; }

    public bool IsNil { get; set; }

    
}

public class ToothList
{
   public List<Tooth> Thooths { get; set; }
}





public class TreatedArches:AttributesPrescriptionQuestionBase
{
    public TreatedArchesType TreatedArchesTypeData   { get; set; }

}

public class TreatedArchesType
{
    public UpperArch UpperArch { get; set; }
    public LowerArch LowerArch { get; set; }

    public string Both { get; set; }

}

public class UpperArch
{
    public bool? DiagnosticSetup { get; set; }
    public bool IsNilDiagnosticSetup {get; set;}

    public OppositeArch OppositeArch { get; set; }

}


public class LowerArch
{
    public bool? DiagnosticSetup { get; set; }
    public bool IsNilDiagnosticSetup {get; set;}

    public OppositeArch OppositeArch { get; set; }

}




public class ArchLevelOverBite: AttributesPrescriptionQuestionBase, INillable
{
    public bool IsNil { get; set; }
    public string MaintainInitialOverbite { get; set; }

    public string MaintainResultantOverbiteAfterAlignment { get; set; }

    public CorrectBite CorrectDeepBite { get; set; }

    public CorrectBite CorrectOpenBite { get; set; }



}
public class CorrectBite
{
    public CorrectBiteType Upper { get; set; }

    public CorrectBiteType Lower { get; set; }
}
public class CorrectBiteType
{
    public bool ExtrudePosterior { get; set; }

    public bool ExtrudeAnterior { get; set; } 
}