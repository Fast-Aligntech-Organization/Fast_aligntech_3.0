

namespace Fast.Core.TreatFiles;

public interface ICommonFormQuestions
{

 
    public string DentalRecords { get; set; }

    public DentalRecordsOrigin DentalRecordsOrigin { get; set; }

}



public class DentalRecordsOrigin:AttributesPrescriptionQuestionBase
{
    public DentalRecordsOriginKind Type { get; set; }

    public DentalRecordsOriginType_Type_Seq DentalRecordsOriginType_Type_Seq { get; set; }

}

public class DentalRecordsOriginType_Type_Seq
{
    public ScanDevice Device { get; set; }
    public ScanSoftware Software { get; set; }

    public ScanOrder Order { get; set; }
}

public class ScanDevice{

    public string Vendor { get; set; }

    public string Model { get; set; }

    public string FirmwareVersion { get; set; }
}

public class ScanSoftware{
    public string Name { get; set; }

    public string Version { get; set; }
}


public class ScanOrder{
    public string Id { get; set; }
    public string Code { get; set; }
}