using System;

namespace Fast.Core.TreatFiles;

public class Header
{
    public bool? Alta {get; set;}

    public bool AltaSpecified {get; set;}

    public bool? CaseGenerationFailed {get; set;}

    public bool CaseGenerationFailedSpecified {get; set;}

    public string ClinicalID  {get; set;}

    public string VIPPatientID  {get; set;}

    public string JDEPatientID  {get; set;}

    public string VIPOrderID  {get; set;}

    public string JDEOrderID  {get; set;}

    public string DID  {get; set;}

    public string TreatmentType  {get; set;}

    public string DoctorRegion  {get; set;}

    public string PlanNumber  {get; set;}

    public string MTPID  {get; set;}

    public string DoctorCountry  {get; set;}

    public bool? PartialTreatment  {get; set;}

    public bool PartialTreatmentSpecified  {get; set;}

    public string OrderType  {get; set;}

    public string TransactionID  {get; set;}

    public string DoctorsMarket  {get; set;}

    public DocumentType DocumentType  {get; set;}

    public ApplianceMaterial ApplianceMaterialType  {get; set;}

    public string ItemNumber  {get; set;}

    public string MaxAllowedStages  {get; set;}

    public PatientType PatientType  {get; set;}

    public DateTime Timestamp  {get; set;}

    public RxSubmissionMode RxSubmissionMode  {get; set;}

    public PrescriptionType PrescriptionType  {get; set;}

    public bool PrescriptionTypeSpecified  {get; set;}

    public string SenderApplication  {get; set;}

    public object receiverApplication  {get; set;}

    public MaxAllowedDifficultyMovement? maxAllowedDifficultyMovement  {get; set;}

    public bool MaxAllowedDifficultyMovementSpecified  {get; set;}


}