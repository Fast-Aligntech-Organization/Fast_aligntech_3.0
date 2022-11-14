using System.Collections.Generic;

namespace Fast.Core.TreatFiles;



public class PrescriptionFormData
{

    public PrescriptionFormData()
    {
        PriorPrescriptions = new();
    }

    public Header Header {get; set;}

    public ClinicalStudies ClinicalStudies {get; set;}

    public object PrescriptionQuestion { get; set; }

    public Preference Preferences {get; set;}



    public List<PrescriptionFormData> PriorPrescriptions { get; set; }

}
