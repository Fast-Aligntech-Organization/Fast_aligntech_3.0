using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core
{
    public interface IProtocolResult
    {

        string Category { get; set; }

        string Title { get; set; }

        double FocusProbability { get; set; }

        bool IsFromTX { get; set; }

        bool IsFromSpecialInstruccions { get; set; }

        bool IsFromWarning { get; set; }

        bool IsFromCalledHistory { get; set; }

    }
}
