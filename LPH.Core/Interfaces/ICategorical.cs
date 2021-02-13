using System;
using System.Collections.Generic;
using System.Text;

namespace LPH.Core.Interfaces
{
    public interface ICategorical
    {
        string TagE { get; }

        string Category { get; }

        string ContentV { get; }

        Type Type { get; }

        int Icon { get; }

        string ToString();

    }
}
