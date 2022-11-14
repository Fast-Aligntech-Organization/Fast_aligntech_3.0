using System.Runtime.Serialization;

namespace Fast.Core.TreatFiles;

public enum ToothStagingForArchExpansion
{
    MolarsMoveFirstFollowedBySimultaneousStaging,
    SimultaneousStaging
}

public enum AttachmentBoostStatus
{
    new_,
    Deleted,
    NotChanged,
    Modified
}

public enum AttachmentPurpose
{
    Rotation,
    Extrusion,
    Retention,
    OverallTreatment
}

public enum PassiveAlignersPreference
{
    YesAddPassiveAligners,
    NoCreateEqualNumberOfActiveAligners,
    None
}

public enum PrimaryTreatedArch
{
    Dual,
    Single
}

public enum TreatmentSetUpLimit
{
    n3,
    n4,
    n5,
    n6,
    n7,
    n8,
    n9,
    n10
}

public enum Units
{
    Mm,
    Cm,
    None
}

public enum Size_Units
{
    Mm,
    Cm,
    Inch
}

public enum TreatmentPlanInstructions
{
    [EnumMember(Value = "SameFinalToothPositionAsTheOriginalClinCheckTreatmentPlan")]
    SameFinalToothPositionAsTheOriginalClinCheckTreatmentPlan,
    [EnumMember(Value = "FinishingForTheCurrentToothPosition")]
    FinishingForTheCurrentToothPosition,
    [EnumMember(Value = "")]
    Other
}

public enum TreatmentObjective
{
    InvisalignAlignersOnly,
    InvisalignAlignersAndRestorativeOptions
}

public enum CrowdingOption
{
    Primarily,
    IfNeeded,
    [EnumMember(Value = "")]
    None
}

public enum TemplateSelected
{
    Yes,
    No,
    NotApplicable
}

public enum ToothSurface
{
    [EnumMember(Value = "Buccal")]
    Buccal,
    [EnumMember(Value = "Lingual")]
    Lingual,
    [EnumMember(Value = "Occlusal")]
    Occlusal
}

public enum OverJet
{
    ShowResultantOverjetAfterAlignment,
    ImproveResultingOverjetWithIPR,
    MaintainInitialOverjet
}

public enum AlignerTrimming
{
    ToCEJLine,
    ToHalfwayBetweenGingivalMarginAndCEJLine
}

public enum PatientsChiefConcern
{
    Crowding,
    Spacing,
    OpenBite,
    DeepBite,
    AnteriorCrossbite,
    NarrowArch,
    FlaredTeeth,
    Overjet,
    UnevenSmile,
    MisshapenTeeth,
    Other,
    SmileLineVertical,
    SmileLineHorizontal,
    BiteRelationship,
    CrowdingUpper,
    CrowdingLower,
    SpacingUpper,
    SpacingLower,
    SmileWidth,
    ToothProminence,
    BiteRel
}

public enum OppositeArch
{
    NothingOnOppositeArch,
    DiagnosticModelOnOppositeArch,
    PassiveAlignersOppositeArch
}

public enum APRelationshipEnum
{
    Maintain,
    ImproveToClass1CanineOnly,
    PartialClass1UpTo4mm,
    CompleteClass1CanineAndMolar,
    ImproveToClass1CanineUpto14Stages,
    PartialClass1UpTo2mm,
    ImproveToClass1MolarOnly,
    ImproveCanineAndMolarUpTo2mm,
    ImproveCanineAndMolar,
    PartialClass1UpTo3mm
}

public enum TemplateName
{
    [EnumMember(Value = "")]
    None,
    Wave_I,
    Overcorrection,
    InvisalignSpaceAsianSpaceSmile
}

public enum AttachmentOrientation
{
    Vertical,
    Horizontal
}

public enum TreatedArch
{
    Upper,
    Lower,
    Both
}

public enum Overcorrection
{
    false_,
    True6By6,
    true_,
    True3By3
}

public enum SAType
{
    None,
    SmileLinesOnly,
    OrthoRestorativeOnly,
    OrthoRestorativeWithSmileLines
}

public enum AttachmentBevel
{
    Incisal,
    Gingival,
    Mesial,
    Distal,
    [EnumMember(Value = "")]
    None
}

public enum DentalRecordsOriginKind
{
    Undefined,
    Impressions,
    Scanner
}

public enum DualArchPreference
{
    SimultaneousStartAndFinish,
    SimultaneousStart,
    SimultaneousFinish,
    AlignDefault
}

public enum PosteriorCrossbite
{
    Maintain,
    Correct
}

public enum ConsernValues
{
    Crowding,
    CrowdingUpper,
    CrowdingLower,
    Spacing,
    SpacingUpper,
    SpacingLower,
    NarrowArch,
    SmileLineVertical,
    Overjet,
    AnteriorCrossbite,
    BiteRelationship,
    FlaredTeeth
}

public enum OptimizedAttachmentSizePreference
{
    Regular,
    LargestFit
}

public enum AdvancementStagingJumps
{
    Increments2mm,
    Single
}

public enum ArchExpansionAmount
{
    LessThanOrEqualTo2mm,
    MoreThan2mm,
    n2mmTo4mm,
    n4mmTo6mm,
    n6mmTo8mm,
    MoreThan8mm
}

public enum AttributeSource
{
    Product,
    Preference,
    Rx
}

public enum TeethToBeTreated
{
    Full,
    Anterior
}

public enum AttachType
{
    [EnumMember(Value = "Ellipsoidal")]
    Ellipsoidal,
    [EnumMember(Value = "Rectangular")]
    Rectangular,
    [EnumMember(Value = "Optimized Extrusion")]
    OptimizedExtrusion,
    [EnumMember(Value = "Optimized Rotation")]
    OptimizedRotation,
    [EnumMember(Value = "Optimized Retention")]
    OptimizedRetention,
    [EnumMember(Value = "")]
    Other
}

public enum CutButtonType
{
    Round
}

public enum ToothNumberingSystem
{
    Universal,
    Palmer,
    FDI
}

public enum FixedLingualRetainerOption
{
    None,
    MaintainLingualRetainerCoverWithViveraRetainer,
    MaintainLingualRetainerTrimViveraRetainerToContour,
    VirtuallyRemoveLingualRetainer,
    MaintainLingualRetainerCoverWithInvisalignRetainer,
    MaintainLingualRetainerTrimInvisalignRetainerToContour
}

public enum ToothSizeDiscrepancy
{
    LeaveSpaceDistalToLaterals,
    LeaveSpaceEquallyAroundLaterals,
    IPROpposingArch,
    LeaveSpaceDistalToCanines,
    LeaveSpaceAroundLaterals,
    LeaveProportionalSpaces,
    CloseAllSpaces
}

public enum CutSlitOrientation
{
    MesialSlit,
    DistalSlit
}

public enum PrecisionCutsQuestion
{
    None,
    SamePlacementAsPreviousTreatmentPlan,
    PlacePrecisionCutsAsNeeded,
    PlacePrecisionCutsAsSpecified
}

public enum AsymmetricalMovementLowerArch
{
    ShiftUpTo2mm,
    DoNotShift,
    ShiftOver2mm
}

public enum AttachmentLocation
{
    GingivalDistal,
    GingivalCenter,
    GingivalMesial,
    CenterDistal,
    CenterCenter,
    CenterMesial,
    IncisalDistal,
    IncisalCenter,
    IncisalMesial,
    None
}

public enum ArchExpansionEnum
{
    IncreasingWidthAll,
    IncreasingWidthCaninesAndPremolars,
    IncreasingWidthPremolarsAndMolars,
    EstablishAndMaintainArchForms,
    ExpandPermanentTeethOnly,
    ExpandPermanentAndPrimaryTeeth
}

public enum EndMAPhasePosition
{
    EdgeToEdge,
    LowerArch1mmBeyond,
    LowerArch2mmBeyond
}

public enum DentalRecords
{
    IntraOralScan,
    Impression,
    NoRecordsSent
}

public enum TreatmentSetUpLimitA
{
    n3,
    n4,
    n5,
    n6,
    n7,
    n8,
    n9,
    n10
}

public enum DocumentType
{
    SO,
    SI,
    SR,
    SL
}

public enum ApplianceMaterial
{
    ST30,
    EX30,
    EX40
}

public enum PatientType
{
    Adult,
    Teen,
    Child
}

public enum RxSubmissionMode
{
    Online,
    Paper
}

public enum PrescriptionType
{
    Suggestive_PVS,
    Suggestive_IOSCAN,
    Prescriptive
}

public enum MaxAllowedDifficultyMovement
{
    Green,
    Blue,
    Black
}

public enum IDelayAttachmentPlacementType_AttachmentBeginStage
{
    n1,
    n2,
    n3,
    n4,
    n5,
    n6,
    n7,
    n8,
    n9,
    n10
}

public enum IDelayStageOfExtractionType_ExtractionBeginStage
{
    n1,
    n2,
    n3,
    n4,
    n5,
    n6,
    n7,
    n8,
    n9,
    n10
}

public enum IDelayStageToStartIPRType_IPRBeginStage
{
    n1,
    n2,
    n3,
    n4,
    n5,
    n6,
    n7,
    n8,
    n9,
    n10
}

public enum IIPRStagingType_IPRBeginStage
{
    Stage1,
    Stage2,
    Stage3,
    Stage4
}

public enum IncisalEdges_LevelAmount
{
    LateralsLevelWithCentrals,
    Laterals0_5mmMoreGingivalThenCentrals,
    GingivalMargins
}

public enum Orientation_UpperArch
{
    PatientsRight,
    PatientsLeft
}

public enum Orientation_LowerArch
{
    PatientsRight,
    PatientsLeft
}

public enum ReasonType
{
    PoorPatientCompliance
}

public enum StagesBefore_Nillable_StagesBefore
{
    n1,
    n2,
    n3,
    n4,
    n5,
    n6,
    n7,
    n8,
    n9,
    n10
}
