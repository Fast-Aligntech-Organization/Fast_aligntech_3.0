using System.Collections.Generic;

namespace Fast.Core;


public interface ISpecialInstructionsResolver
{
    string RawInstructions
    {
        get; set;
    }
    string FormInstructionsUpperArch
    {
        get;
    }

    string FormInstructionsLowerArch
    {
        get;
    }

    string PreferenceInstrucions
    {
        get;
    }

    string FormInstructions
    {
        get;
    }

    Dictionary<string, string> SplitInstructions(string instructions, IEnumerable<string> tokens = null);









}
