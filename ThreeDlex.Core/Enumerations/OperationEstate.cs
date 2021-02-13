using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeDlex.Core.Enumerations
{
    /// <summary>
    /// Representa el estado actual de operacion de una maquina 3D
    /// </summary>
    public enum MachineEstate
    {
        Estopped,
        Pause,
        Starting,
        Working,
        Ending,
        Inoperable,
        Error


        


    }

    public enum OperationEstate
    {
        Ready,
        Clogged,
        InMaintenance,

        


    }
}
