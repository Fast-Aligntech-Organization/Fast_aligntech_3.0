using System;
using System.Threading.Tasks;
using Fast.Core.TreatFiles;

namespace Fast.Core;

public class BiteResetProtocol : IProtocol
{
    public string Category { get; set; } = "BiteReset";

    public string Title { get; set; } = "Bite Reset";

    public IProtocolResult Evaluate(PrescriptionFormData tx, ILuisService namedEntityRecognition)
    {
        throw new NotImplementedException();
    }

    public Task<IProtocolResult> EvaluateAsync(PrescriptionFormData tx, ILuisService namedEntityRecognition)
    {
        throw new NotImplementedException();
    }
}
