using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core
{
    public interface IProtocolService
    {


        Task<ICollection<IProtocolResult>> ProtocolResultsAsync(ICollection<IProtocol> protocols);

        Task<IProtocolResult> SpecificProtocolResultAsync(IProtocol protocol);


    }
}
