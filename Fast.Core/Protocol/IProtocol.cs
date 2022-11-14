using System.Threading.Tasks;
using Fast.Core.TreatFiles;

namespace Fast.Core;

public interface IProtocol
{

    string Category { get; set; }

    string Title { get; set; }

    IProtocolResult Evaluate(PrescriptionFormData tx, ILuisService namedEntityRecognition);

    Task<IProtocolResult> EvaluateAsync(PrescriptionFormData tx, ILuisService namedEntityRecognition);


}


